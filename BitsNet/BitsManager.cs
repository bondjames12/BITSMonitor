using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Bits;
using System.IO;
using System.Web;

namespace BitsNet
{

    public enum BitsJobActions
    {
        CANCEL_JOB,
        RESUME_JOB,
        COMPLETE_JOB,
		SUSPEND_JOB
    }

    public enum BitsJobState
    {
        QUEUED = 0,
        CONNECTING = 1,
        TRANSFERRING = 2,
        SUSPENDED = 3,
        ERROR = 4,
        TRANSIENT_ERROR = 5,
        TRANSFERRED = 6,
        ACKNOWLEDGED = 7,
        CANCELLED = 8,
    }

    public class BitsJob
	{
		#region Properties
		private IBackgroundCopyJob _job;

        private string _fileName = string.Empty;
		/// <summary>
		/// name of the file the content of the job will be written to (choosen automatically, or by the user in AddJob dialog)
		/// </summary>
        public string FileName
        {
            get { return _fileName; }
            protected set { _fileName = value; }
        }

        private string _url = string.Empty;
		/// <summary>
		/// Url the file is being uploaded/downloaded to/from
		/// </summary>
        public string Url
        {
            get { return _url; }
            protected set { _url = value; }
        }

        private string _displayName = string.Empty;
		/// <summary>
		/// display name of the job
		/// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            protected set { _displayName = value; }
        }


        private string _description = string.Empty;
		/// <summary>
		/// Description of the job
		/// </summary>
        public string Description
        {
            protected get { return _description; }
            set { _description = value; }
        }
        
        private ulong _bytesTotal = 0;
		/// <summary>
		/// return the overall size of the transmitted file
		/// </summary>
        public ulong BytesTotal
        {
            protected set { _bytesTotal = value; }
            get { return _bytesTotal; }
        }

		private ulong _bytesTransferred = 0;
		/// <summary>
		/// returns the amount of bytes already transferred
		/// </summary>
        public ulong BytesTransferred
        {
            protected set { _bytesTransferred = value; }
            get { return _bytesTransferred; }
        }

        private float _percentComplete = 0.0f; 
		/// <summary>
		/// Calculates and returns percentage of the completion of the job
		/// calculation is based on TotalBytes and BytesTransferred
		/// </summary>
        public float PercentComplete
        {
            protected set { _percentComplete = value; }
            get 
            {
				return _bytesTransferred * 1.0f / _bytesTotal;// *100.0f;
            }
        }

        private BitsJobState _jobState;
		/// <summary>
		/// State of the job
		/// </summary>
        public BitsJobState JobState
        {
            protected set { _jobState = value; }
            get { return _jobState; }
        }

        private string _jobStateDescription = string.Empty;
		/// <summary>
		/// Text description of the state of the job.
		/// </summary>
        public string JobStateDescription
        {
            get {   return _jobStateDescription; }
            protected set 
            {
                if (string.IsNullOrEmpty(value))
                    return;

                // lenght of 'BG_JOB_STATE_'
                _jobStateDescription = value.Substring(13);
                _jobState = (BitsJobState)Enum.Parse( _jobState.GetType(), _jobStateDescription);
            }
		}

		private Guid _jobGuid;
		/// <summary>
		/// return Guid of the job
		/// </summary>
		public Guid Guid
		{
			get
			{
				if ( (_jobGuid == null) || ( _jobGuid == Guid.Empty ) )
					_job.GetId(out _jobGuid);
				return _jobGuid;
			}
		}
		#endregion

		internal BitsJob(IBackgroundCopyJob job)
        {
            _job = job;

            RefreshJobProperties();
            RefreshFileProperties();
        }

        private void RefreshJobProperties( )
        {
            _job.GetDisplayName(out _displayName);
            _job.GetDescription(out _description);
            _BG_JOB_PROGRESS jobProgress;
            _job.GetProgress(out jobProgress);
            _bytesTotal = jobProgress.BytesTotal;
            _bytesTransferred = jobProgress.BytesTransferred;
            BG_JOB_STATE jobState;
            _job.GetState(out jobState);
            this.JobStateDescription = Enum.GetName(jobState.GetType(), jobState);
        }

        private void RefreshFileProperties()
        {
            IEnumBackgroundCopyFiles files;
            _job.EnumFiles(out files);
            uint filesCount;
            files.GetCount(out filesCount);
            if (filesCount < 1)
                return;
            IBackgroundCopyFile file;
            uint filesFetched;
            files.Next(1, out file, out filesFetched);
            file.GetLocalName(out _fileName);
            _fileName = _fileName.Substring(_fileName.LastIndexOf("\\") + 1);
            file.GetRemoteName(out _url);
        }

        internal void CompleteJob( )
        {
            _job.Complete();
        }

        internal void ResumeJob()
        {
            _job.Resume();
        }

        internal void CancelJob()
        {
            _job.Cancel();
        }

		internal void SuspendJob()
		{
			_job.Suspend();
		}

    }

    //public class BitsFile
    //{
    //}

    public static class BitsManager
    {
        private static IBackgroundCopyManager _bcm = null;
        private static Dictionary<Guid, BitsJob> _jobs;

        private static bool _autostart = true;

        static BitsManager()
        {
            _bcm = (IBackgroundCopyManager)new BackgroundCopyManager();
            _jobs = new Dictionary<Guid, BitsJob>();
        }

		public static Dictionary<Guid,BitsJob> GetAllJobs()
        {
            uint dwFlags = 0; // 0 - to get all jobs
            IEnumBackgroundCopyJobs bcmJobs;
            _bcm.EnumJobs(dwFlags, out bcmJobs);
            uint jobsCount;
            bcmJobs.GetCount(out jobsCount);
			_jobs.Clear();
            for (int i = 0; i < jobsCount; i++)
            {
                IBackgroundCopyJob job;
                uint jobsFetched;
                bcmJobs.Next(1, out job, out jobsFetched);
                if (jobsFetched != 1)
                    throw new Exception("improper number of jobs fetched");

                Guid jobID;
                job.GetId(out jobID);
                _jobs.Add(jobID, new BitsJob(job));
            }
			return _jobs;
        }

		/// <summary>
		/// Completes a job with specified Guid
		/// </summary>
		/// <param name="jobGuid"></param>
        public static void CompleteJob(Guid jobGuid)
        {
            _jobs[jobGuid].CompleteJob();
        }

		/// <summary>
		/// Cancels a job with specified Guid
		/// </summary>
		/// <param name="jobGuid"></param>
        public static void CancelJob(Guid jobGuid)
        {
            _jobs[jobGuid].CancelJob();
        }

        /// <summary>
        /// Resumes a job with specified Guid
        /// </summary>
        /// <param name="jobGuid"></param>
		public static void ResumeJob(Guid jobGuid)
        {
            _jobs[jobGuid].ResumeJob();
        }

		public static void SuspendJob(Guid jobGuid)
		{
			_jobs[jobGuid].SuspendJob();
		}


        /// <summary>
        /// Performs choosen action on all selected jobs
        /// </summary>
        /// <param name="guids"></param>
        /// <param name="action"></param>
        public static void PerformActions(List<Guid> guids, BitsJobActions action)
        {
            foreach (Guid g in guids)
            {
                PerformAction(g, action);
            }
        }

        /// <summary>
        /// Perform specified action on selected job
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="action"></param>
        public static void PerformAction(Guid guid, BitsJobActions action)
        {
            if (!_jobs.ContainsKey(guid))
                return;

            switch (action)
            {
                case BitsJobActions.CANCEL_JOB:
                    _jobs[guid].CancelJob();
                    break;
                case BitsJobActions.COMPLETE_JOB:
                    _jobs[guid].CompleteJob();
                    break;
                case BitsJobActions.RESUME_JOB:
                    _jobs[guid].ResumeJob();
                    break;
				case BitsJobActions.SUSPEND_JOB:
					_jobs[guid].SuspendJob();
					break;
            }
        }

		/// <summary>
		/// Adds new job to BITS
		/// </summary>
		/// <param name="url">url (at the moment source only) where to download file from</param>
		/// <param name="jobName">unique name of the job</param>
		/// <param name="directory"></param>
        public static void AddJob(string url, string jobName, string directory)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(directory))
            {
                throw new ArgumentNullException("url or destination directory not provided!");
            }

            Guid jobGuid;
            IBackgroundCopyJob job;
            _bcm.CreateJob(jobName, BG_JOB_TYPE.BG_JOB_TYPE_DOWNLOAD, out jobGuid, out job);
            string localName = HttpUtility.UrlDecode( url.Substring(url.LastIndexOf("/") + 1) );
            string fullFileName = Path.Combine(directory + Path.DirectorySeparatorChar, localName);
			fullFileName = GetNonExistingFileName(fullFileName);
            job.AddFile(url, fullFileName);
            if (BitsManager._autostart)
                job.Resume();
        }

		/// <summary>
		/// Gets filename and makes sure that file with the name does not exist. 
		/// If file with specified name exist - adds sufix '-(x)' (where x is: 0,1,2,3...)
		/// </summary>
		/// <param name="filename">filename to check if file exists</param>
		/// <returns>non existing filename</returns>
		private static string GetNonExistingFileName(string filename)
		{
			string newFileName = filename;
			uint i = 0;
			string extension = filename.Substring(filename.LastIndexOf(".")+1);
			string noextFilename = filename.Substring(0, filename.LastIndexOf("."));
			while (File.Exists(newFileName))
			{
				newFileName = string.Format("{0}-({1}).{2}", noextFilename, i++, extension);
			}
			return newFileName;
		}
    }
}

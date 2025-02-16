using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Repository.IRepository;

namespace ApplicationStatusAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _data;
        private readonly ILoggerFactory _loggerFactory;

        public UnitOfWork(DataContext data, ILoggerFactory loggerFactory)
        {
            _data = data;
            _loggerFactory = loggerFactory;
            Location = new LocationRepository(_data, _loggerFactory);
            JobApplication = new JobApplicationStatusRepository(_data, _loggerFactory);
            SubmissionStatus = new SubmissionStatusRepository(_data, _loggerFactory);
            ApplicationStatus = new ApplicationStatusRepository(_data, _loggerFactory);
            Source = new SourceRepository(_data, _loggerFactory);   
        }

        public ILocationRepository Location { get; private set; }

        public IJobApplicationRepository JobApplication { get; private set; }

        public ISubmissionStatusRepository SubmissionStatus { get; private set; }

        public IApplicationStatusRepository ApplicationStatus { get; private set; }

        public ISourceRepository Source { get; private set; }
    }
}

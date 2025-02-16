namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ILocationRepository Location { get; }
        IJobApplicationRepository JobApplication { get; }
        ISubmissionStatusRepository SubmissionStatus { get; }
        IApplicationStatusRepository ApplicationStatus { get; }
        ISourceRepository Source { get; }
    }
}

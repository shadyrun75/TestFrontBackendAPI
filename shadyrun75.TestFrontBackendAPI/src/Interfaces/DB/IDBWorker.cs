namespace shadyrun75.TestFrontBackendAPI.Interfaces.DB
{
    public interface IWorker
    {
        IAuthorization Authorization { get; }
        ITest Test { get; }
    }
}
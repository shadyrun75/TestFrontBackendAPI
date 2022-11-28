namespace shadyrun75.TestFrontBackendAPI.Interfaces.DB
{
    public interface IWorker
    {
        IAuthorization Authorization { get; }
        IKaktus Kaktus { get; }
    }
}
namespace DataProcessorService.Abstractions
{
    public interface IGetMessageService
    {
        Task GetMessageFromRabbitMQ(CancellationToken cancellationToken); 
    }
}

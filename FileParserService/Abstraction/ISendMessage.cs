namespace FileParserService.Abstraction
{
    public interface ISendMessage
    {
        Task Send(string message, CancellationToken cancellationToken); 
    }
}

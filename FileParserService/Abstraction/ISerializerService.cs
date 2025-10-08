namespace FileParserService.Abstraction
{
    public interface ISerializerService
    {
        Task<string> Serialize(string path);
    }
}

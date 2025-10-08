
namespace DataProcessorService.Abstractions
{
    public interface ISaveMessageStorage
    {
        Task Executes(DataProcessorService.Models.InstrumentStatus instrumentStatus, CancellationToken cancellationToken); 
    }
}

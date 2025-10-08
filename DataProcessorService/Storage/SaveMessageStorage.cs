using DataProcessorService.Abstractions;
using DataProcessorService.Storage.DbContexts;
using DataProcessorService.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProcessorService.Storage
{
    internal class SaveMessageStorage
        (IServiceScopeFactory _scopeFactory) : 
        ISaveMessageStorage
    {
        public async Task Executes(DataProcessorService.Models.InstrumentStatus instrumentStatus, CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetRequiredService<Module_SqliteContext>();
            var modules = new List<Modules>();

            foreach (var divaceStatus in instrumentStatus.DivaceStatus)
            {
                modules.Add(new Modules() { ModuleCategoryID = divaceStatus.ModuleCategoryID, ModuleState = divaceStatus.RapidControlStatus.ModuleState });
            }

            foreach (var module in modules)
            {
                var existing = await _dbContext.Modules.FirstOrDefaultAsync(m => m.ModuleCategoryID == module.ModuleCategoryID, cancellationToken);
                if (existing != null)
                {
                    _dbContext.Modules.Update(module);
                }
                else
                {
                    _dbContext.Modules.Add(module);
                }
            }
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

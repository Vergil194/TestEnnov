using Application.Gateways;
using Domain;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public class CompanyDataSyncService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CompanyDataSyncService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(15));
            do
            {
                await SyncData();
            }while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested);
        }

        private async Task SyncData()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var api = scope.ServiceProvider.GetRequiredService<IZefixApiPublicServices>();
                var db = scope.ServiceProvider.GetRequiredService<IGeneriqueRepository<Company>>();

                //var companyList = await api.GetCompaniesCHE();

            }
        }
    }
}

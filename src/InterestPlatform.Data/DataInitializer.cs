using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterestPlatform.Data
{
    public class DataInitializer
    {

        private readonly IServiceProvider _serviceProvider;

        private readonly IServiceScopeFactory _scopeFactory;

        private readonly ILogger _logger;

        public DataInitializer(
            ILoggerFactory logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger.CreateLogger(nameof(DataInitializer));
            _serviceProvider = serviceProvider;
            _scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        public virtual void Run()
        {
            _logger.LogVerbose("Started seeding data");
            UsingContext(context => context.Database.EnsureCreated());
            _logger.LogVerbose("Completed seeding data");
        }

        private void UsingContext(Action<ApplicationDbContext> action)
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            using (var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                action(context);
            }
        }
    }
}

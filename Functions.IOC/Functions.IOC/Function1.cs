using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Project.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Functions.IOC
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("mytopic", "mysubscription", AccessRights.Manage, Connection = "")]string mySbMsg, TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            var container = new ContainerBuilder().RegisterModule(new CoreAppModule()).Build();

            // Sample service instance
            var sampleService = container.GetService<ISampleService>();
        }
    }
}

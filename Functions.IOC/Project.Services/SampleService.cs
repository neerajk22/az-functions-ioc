using System;
using System.Threading.Tasks;

namespace Project.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleService _sampleService;
        public SampleService(ISampleService sampleService)
        {
            this._sampleService = sampleService ?? throw new ArgumentNullException(nameof(sampleService));
        }

        public async Task<bool> TestMethodAsync()
        {
            await Task.CompletedTask;
            return true;
        }
    }
}

using System.Threading.Tasks;

namespace Project.Services
{
    public interface ISampleService
    {
        Task<bool> TestMethodAsync();
    }
}

using System.Threading.Tasks;

namespace ServiceOne.Interfaces
{
    public interface IServiceTwoHelper
    {
       Task<string> GetMessage();
    }
}

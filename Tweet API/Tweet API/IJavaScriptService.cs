using System.Threading.Tasks;

namespace Tweet_API
{
    public interface IJavaScriptService
    {
       
            Task<string> Hello(string name);
          
    }
}
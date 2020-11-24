using System.Threading.Tasks;

namespace TinyIoC.Base
{
    public class ViewModelBase : ExtendedBindableObject
    {
        public virtual Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}
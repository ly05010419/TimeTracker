using System.Threading.Tasks;

namespace TinyIoC.Base
{
    public class ViewModelBase : ExtendedBindableObject
    {
        private string _title;

        public virtual Task InitAsync()
        {
            return Task.CompletedTask;
        }
    }
}
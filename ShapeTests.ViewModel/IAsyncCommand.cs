using System.Threading.Tasks;
using System.Windows.Input;

namespace ShapeTest.Wpf
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
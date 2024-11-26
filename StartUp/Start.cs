using ConsoleApp;
using Ninject;
using Presenter;
using Shared;

namespace Start
{
    public class Start
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new SimpleConfigModule());
            if (GetViewString.ViewString() == "Console")
            {
                var presenter = kernel.Get<IPresenter>();
                var Console = kernel.Get<IMainView>();
                Console.Run();
            }
            if (GetViewString.ViewString() == "Form")
            {
                var presenter = kernel.Get<IPresenter>();
                var Form = kernel.Get<IMainView>();
                Form.Run();
            }
        }
    }
}

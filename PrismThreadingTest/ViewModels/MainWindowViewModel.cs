using Prism.Mvvm;

namespace PrismThreadingTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Test App";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}

using Prism.Regions;
using System.Windows;

namespace PrismThreadingTest.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRegionManager _regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }


    }
}

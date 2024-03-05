//using System.Windows;
//using Carshop.Core.Entities;

//namespace CarShop.UI
//{
//    public partial class MainWindow : Window
//    {
//        private readonly MainWindowModel _viewModel;

//        public MainWindow(MainWindowModel viewModel)
//        {
//            InitializeComponent();
//            _viewModel = viewModel;
//            DataContext = _viewModel;
//        }

//        private void AddCar_Click(object sender, RoutedEventArgs e)
//        {
//            _viewModel.AddCar(new Car());
//        }

//        private void AddClient_Click(object sender, RoutedEventArgs e)
//        {
//            _viewModel.AddClient(new Client());
//        }
//    }
//}

using Carshop.Core.Entities;
using System.ComponentModel;
using System.Windows;

namespace CarShop.UI
{
    public partial class MainWindow : Window
    {
        private List<string> _excludedColumns = new List<string>()
        {
            "Client",
            "Cars"
        };
        private readonly MainWindowModel _viewModel;

        public MainWindow(MainWindowModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddCar(_viewModel.Cars.Last());
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddClient(_viewModel.Clients.Last());
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveChanges();
        }

        private void OnAutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (_excludedColumns.Contains(propertyDescriptor.DisplayName))
            {
                e.Cancel = true;
            }
        }
    }
}


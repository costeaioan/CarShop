
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
            RefreshClientDataGrid();
            RefreshCarsDataGrid();
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null && button.CommandParameter != null)
            {
                int id = (int)button.CommandParameter; 
                _viewModel.DeleteClient(id);
            }
        }

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null && button.CommandParameter != null)
            {
                int id = (int)button.CommandParameter;
                _viewModel.DeleteCar(id);
            }
        }

        private void RefreshClientDataGrid()
        {
            var updatedData = _viewModel.GetClients();
            clientsDataGrid.ItemsSource = updatedData;
        }

        private void RefreshCarsDataGrid()
        {
            var updatedData = _viewModel.GetCars();
            carsDataGrid.ItemsSource = updatedData;
        }

        private void OnAutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;


            // before first property of each table we add the delete button
            if (carsDataGrid.Columns.Count == 0 && !carsDataGrid.Columns.Any(column => column.Header.Equals("Delete")))
            {
                var deleteColumn = new DataGridTemplateColumn
                {
                    Header = "Delete",
                    CellTemplate = CreateDeleteButtonTemplate(DeleteCar_Click)
                };

                carsDataGrid.Columns.Add(deleteColumn);
            }
            else if (clientsDataGrid.Columns.Count == 0 && !clientsDataGrid.Columns.Any(column => column.Header.Equals("Delete")))
            {
                var deleteColumn = new DataGridTemplateColumn
                {
                    Header = "Delete",
                    CellTemplate = CreateDeleteButtonTemplate(DeleteClient_Click)
                };
                clientsDataGrid.Columns.Add(deleteColumn);
            }
            if (_excludedColumns.Contains(propertyDescriptor.DisplayName))
            {
                e.Cancel = true;
            }
        }

        private DataTemplate CreateDeleteButtonTemplate(Action<object, RoutedEventArgs> action)
        {
            var dataTemplate = new DataTemplate();
            var buttonFactory = new FrameworkElementFactory(typeof(Button));
            buttonFactory.SetValue(Button.ContentProperty, "X");
            buttonFactory.SetValue(Button.BackgroundProperty, Brushes.Red); // Use Brushes.Red here
            buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(action));
            buttonFactory.SetBinding(Button.CommandParameterProperty, new Binding("Id")); // Binding to the ID property
            dataTemplate.VisualTree = buttonFactory;
            return dataTemplate;
        }
    }
}


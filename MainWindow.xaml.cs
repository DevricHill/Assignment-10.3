using Assignment_10._3.Models;
using Assignment_10._3.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_10._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD manager = new CRUD();
        private void RefreshGrid()
        {
            carGrid.ItemsSource = null;
            carGrid.ItemsSource = manager.GetCars();
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            btnSubmit.IsEnabled = false;
            btnUpdate.IsEnabled = false;
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            txtVIN.Text = (manager.GetCars().Max(x => x.VIN + 1).ToString());
            txtVIN.IsReadOnly = true;
            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtPrice.Clear();

            btnSubmit.IsEnabled = true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMake.Text) &&
                !string.IsNullOrEmpty(txtModel.Text) &&
                !string.IsNullOrEmpty(txtYear.Text) &&
                !string.IsNullOrEmpty(txtPrice.Text)
                )
            {
                Car obj = new Car()
                {
                    VIN = int.Parse(txtVIN.Text),
                    Make = txtMake.Text,
                    Model = txtModel.Text,
                    Year = int.Parse(txtYear.Text),
                    Price = double.Parse(txtPrice.Text)
                    
                };

                manager.AddCar(obj);
                RefreshGrid();
                btnSubmit.IsEnabled = false;

            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Car car = carGrid.SelectedItem as Car;

            if (car != null)
            {
                txtVIN.Text = car.VIN.ToString();
                txtMake.Text = car.Make.ToString();
                txtModel.Text = car.Model.ToString();
                txtYear.Text = car.Year.ToString();
                txtPrice.Text = car.Price.ToString();

                btnUpdate.IsEnabled = true;
                btnSubmit.IsEnabled = false;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Car car = carGrid.SelectedItem as Car;
            bool isDeleted = MessageBox.Show("Are you sure you want to delete?", "Warning!", MessageBoxButton.YesNo) == MessageBoxResult.Yes;

            if (car != null && isDeleted)
            {
                manager.DeleteCar(car.VIN);
                RefreshGrid();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVIN.Text))
            {
                var car = manager.GetCar(int.Parse(txtVIN.Text));
                if(car != null)
                {
                    car.Make = txtMake.Text;
                    car.Model = txtModel.Text;
                    car.Year = int.Parse(txtYear.Text);
                    car.Price = double.Parse(txtPrice.Text);

                    manager.UpdateCar(car.VIN, car);
                    RefreshGrid();
                    btnUpdate.IsEnabled = false;
                }
            }
        }
    }
}
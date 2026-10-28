using System.Configuration;
using System.Data;
using System.Windows;
using Assignment_10._3.Data;

using Microsoft.EntityFrameworkCore;

namespace Assignment_10._3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Records.context = new CarContext();
            Records.context.Database.EnsureCreated();
            Records.context.Cars.Load();
        }
    }

}

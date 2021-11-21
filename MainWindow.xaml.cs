using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicineTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;

            NavigateTo(PageType.AddUser);
        }

        public void NavigateTo(PageType page)
        {
            switch (page)
            {
                case PageType.AddUser:
                    _NavigationFrame.Navigate(new AddUserForm());
                    break;
                case PageType.ShowRecords:
                    _NavigationFrame.Navigate(new MedicineRecords());
                    break;
                //case PageType.AddRecord:
                //    _NavigationFrame.Navigate(new AddUserForm());
                //    break;
            }
        }
    }
}

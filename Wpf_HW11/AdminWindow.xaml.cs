using HW11.BL.Controller;
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
using System.Windows.Shapes;

namespace Wpf_HW11
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private UserController userController;
        public AdminWindow(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
            this.Title = $"{userController.CurentUser.Name} - {userController.CurentUser.Status}";
            ListBox_Users.ItemsSource = userController.Users;
        }

        private void BTN_Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            AuthWin authWin = new();
            authWin.Show();
            this.Close();
        }

        
        private void ListBox_Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Title = ListBox_Users.SelectedItem.ToString();
        }
    }
}

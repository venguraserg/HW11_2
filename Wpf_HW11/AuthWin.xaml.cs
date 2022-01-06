using HW11.BL.Controller;
using HW11.BL.Model;
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
    /// Логика взаимодействия для AuthWin.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
        }

        private void BTN_Auth_Click(object sender, RoutedEventArgs e)
        {
            string tempName = TB_UserName.Text;
            UserController userController = new UserController(tempName);
            if (userController.IsNewUser) { MessageBox.Show("Вы новый пользователь\n ваш статус - консультант\nдля изменения обратитесь к Администратору"); }
            if (userController.CurentUser is Administrator)
            {
                var adminWindow = new AdminWindow(userController);
                adminWindow.Show();
            }
            else
            {
                var mainWindow = new MainWindow(userController);
                mainWindow.Show();
            }
            
            this.Close();
        }
    }
}

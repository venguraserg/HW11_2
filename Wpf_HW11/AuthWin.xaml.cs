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
            if (userController.IsNewUser) { MessageBox.Show("Вы новый пользователь\nваш статус - консультант\nдля изменения обратитесь к Администратору\nили войдите под Admin"); }
            if(userController.Clients.Count == 0) 
            { 
                var result = MessageBox.Show("Список клиентов пуст, заволнить автоматически?", "???", MessageBoxButton.YesNo); 
                if(result == MessageBoxResult.Yes)
                {
                    userController.ClientAutofill(15);
                    //userController.clientController.Clients = userController.clients;
                }
            }

            if (userController.CurentUser is Administrator)
            {
                var adminWindow = new AdminWindow(userController);
                adminWindow.Show();
            }
            else
            {

                var mainWindow = new MainWindow(userController);
                mainWindow.Show();


                //switch (userController.CurentUser.GetType().Name)
                //{
                //    case "Consultant":
                //        //var consultWindow = new ConsultWindow(userController);
                //        //consultWindow.Show();
                //        var mainWindow = new MainWindow(userController);
                //        mainWindow.Show();
                //        break;

                //    case "Manager":
                //        /*var*/ mainWindow = new MainWindow(userController);
                //        mainWindow.Show();
                //        break;

                //    default:
                //        break;
                //}
            }
            this.Close();
        }
    }
}

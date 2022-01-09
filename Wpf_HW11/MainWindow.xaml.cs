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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_HW11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController userController;
        private Client selectedClient;
        

        public MainWindow(UserController userController)
        {
            InitializeComponent();
            selectedClient = new Client();
            this.userController = userController;
            TB_User.Text = $"Пользователь: {userController.CurentUser.Name}";
            TB_UserStatus.Text = $"Статус: {userController.CurentUser.Status}";           
            
            ListView_Clints.ItemsSource = this.userController.clients;
            
            Surname.IsEnabled = userController.CurentUser is Consultant ? false : true;
            Name.IsEnabled = userController.CurentUser is Consultant ? false : true;
            Patronymic.IsEnabled = userController.CurentUser is Consultant ? false : true;
            PassNumber.IsEnabled = userController.CurentUser is Consultant ? false : true;
            BTN_Add.IsEnabled = userController.CurentUser is Consultant ? false : true;
            BTN_Delete.IsEnabled = userController.CurentUser is Consultant ? false : true;
        }

        

        private void BTN_Change_Click(object sender, RoutedEventArgs e)
        {
            
            var tempSurname = Surname.Text.Trim();
            var tempName = Name.Text.Trim();
            var tempPatronymic = Patronymic.Text.Trim();
            var tempPhoneNumber = PhoneNumber.Text.Trim();
            var tempPassNumber = PassNumber.Text.Trim();

            if (ListView_Clints.SelectedItem == null)
            {
                MessageBox.Show("Не выбран клиетн!");

            }
            else if(tempPhoneNumber.Length > 7 && tempPhoneNumber.Length < 12)
            {
                PhoneNumber.ToolTip = "Не корректный номер, необходимо от 6 до 12 символов";
                PhoneNumber.Background = Brushes.Red;
            }
            else
            {
                PhoneNumber.ToolTip = "";
                PhoneNumber.Background = Brushes.Transparent;
                selectedClient = ListView_Clints.SelectedItem as Client;
                userController.UpdateClient(tempSurname, tempName, tempPatronymic, tempPhoneNumber, tempPassNumber, selectedClient);
                ListView_Clints.Items.Refresh();
                
            }

        }

        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            var tempSurname = Surname.Text.Trim();
            var tempName = Name.Text.Trim();
            var tempPatronymic = Patronymic.Text.Trim();
            var tempPhoneNumber = PhoneNumber.Text.Trim();
            var tempPassNumber = PassNumber.Text.Trim();
            bool result = userController.AddClient(tempSurname, tempName, tempPatronymic, tempPhoneNumber, tempPassNumber);
            ListView_Clints.Items.Refresh();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            userController.DeleteClient(ListView_Clints.SelectedItem as Client);
            ListView_Clints.Items.Refresh();
        }
    }
}

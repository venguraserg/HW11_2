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
    /// Логика взаимодействия для CrudWindow.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
        private Client _client;
        private Window _w;

        public CrudWindow(Client client, MainWindow window)
        {
            InitializeComponent();
            _client = client;
            _w = window;

            TB_Surname.Text = client.Surname;
            TB_Name.Text = client.Name;
            TB_Patronymic.Text = client.Patronymic;
            TB_PhoneNumber.Text = client.PhoneNumber;
            TB_PassNumber.Text = client.PassNumber;

        }

        private void BTN_Change_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

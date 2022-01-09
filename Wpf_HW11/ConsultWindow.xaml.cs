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
    /// Логика взаимодействия для ConsultWindow.xaml
    /// </summary>
    public partial class ConsultWindow : Window
    {
        private UserController userController;
        public ConsultWindow(UserController userController)
        {
            InitializeComponent();
            this.userController = userController;
        }
    }
}

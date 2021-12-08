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

namespace ImageProgram
{
    /// <summary>
    /// UserMenu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserMenu : UserControl
    {
        MainControl mainControl = new MainControl();

        public UserMenu()
        {
            InitializeComponent();
            int num = mainControl.loginUserName.Text.IndexOf("님");
            loginUser.Text = mainControl.loginUserName.Text.Substring(0, num);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void userInformationAlter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

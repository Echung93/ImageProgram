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

namespace ImageProgram
{
    /// <summary>
    /// loginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserMenu userMenu = new UserMenu();
        MainControl mainControl = new MainControl();
        MainWindow mainWindow = new MainWindow();
        AddressAlter addressAlter = new AddressAlter();
        PasswordAlter passwordAlter = new PasswordAlter();
        PhoneNumberAlter phoneNumberAlter = new PhoneNumberAlter();
        ViewUserInformation viewUserInformation = new ViewUserInformation();
        ModifyUserInformation modifyUserInformation = new ModifyUserInformation();
        
        public static string loginUser;

        public LoginWindow()
        {
            InitializeComponent();
            loginGrid.Children.Add(userMenu);
            modifyUserInformation.Btn_back.Click += Btn_back_Click;
            modifyUserInformation.Btn_userInformation.Click += Btn_userInformation_Click;
            modifyUserInformation.Btn_addressAlter.Click += Btn_addressAlter_Click;
            modifyUserInformation.Btn_passwordAlter.Click += Btn_passwordAlter_Click;
            modifyUserInformation.Btn_phoneNumberAlter.Click += Btn_phoneNumberAlter_Click;
            addressAlter.Btn_back.Click += Btn_back_Click1;
            passwordAlter.Btn_back.Click += Btn_back_Click1;
            phoneNumberAlter.Btn_back.Click += Btn_back_Click1;
            viewUserInformation.Btn_back.Click += Btn_back_Click1;
            userMenu.logout.Click += Btn_logout_Click;
            userMenu.userDelete.Click += Btn_userDelete_Click;
            userMenu.userInformationAlter.Click += Btn_userInformationAlter_Click;
            userMenu.searchImage.Click += Btn_searchImage_Click;

        }

        public void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Btn_userDelete_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(userMenu);
        }

        public void Btn_userInformationAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(modifyUserInformation);
        }

        public void Btn_searchImage_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(userMenu);
        }

        public void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(userMenu);
        }

        public void Btn_back_Click1(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(modifyUserInformation);
        }

        public void Btn_userInformation_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(viewUserInformation);
        }

        public void Btn_passwordAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(passwordAlter);
        }

        public void Btn_addressAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(addressAlter);
        }

        public void Btn_phoneNumberAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(phoneNumberAlter);
        }

    }
}

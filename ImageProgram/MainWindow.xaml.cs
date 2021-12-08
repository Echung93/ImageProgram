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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        MainControl mainControl = new MainControl();
        UserControl1 userControl1 = new UserControl1();
        RegisterPage registerPage = new RegisterPage();
        UserMenu userMenu = new UserMenu();
        Find find = new Find();
        FindID findID = new FindID();
        FindPW findPW = new FindPW();
        Window loginWin;

        public static string name;
        //Window testWin;

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(mainControl);

            mainControl.Btn_login.Click += Btn_login_Click;
            mainControl.Btn_register.Click += Btn_register_Click;
            mainControl.Btn_findPassword.Click += Btn_findPassword_Click;
            userControl1.Btn_back.Click += Btn_back_Click;
            registerPage.Btn_back.Click += Btn_back_Click;
            find.Btn_back.Click += Btn_back_Click;
            find.Btn_findID.Click += Btn_findID_Click;
            find.Btn_findPW.Click += Btn_findPW_Click;
            findID.Btn_back.Click += Btn_back_Click1;
            findPW.Btn_back.Click += Btn_back_Click1;
            findID.findPW.Click += Btn_findPW_Click;
            //findID.Btn_back.Click += Btn_back_Click;
            //findPW.Btn_back.Click += Btn_back_Click;
        }

        public void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(mainControl);
        }

        public void Btn_back_Click1(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(find);
        }

        public void Btn_register_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(registerPage);
        }

        public void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            name = mainControl.login();
            userMenu.loginUser.Text = $"{name}님 환영합니다.";

            if (name != null)
            {
                loginWin = new LoginWindow();
                loginWin.Owner = this;
                loginWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                int num = mainControl.loginUserName.Text.IndexOf("님");
                name = mainControl.loginUserName.Text.Substring(0,num);
                
                this.Hide();
                loginWin.ShowDialog();
                this.Show();
                MainGrid.Children.Add(mainControl);
            }

            else
            {
                MainGrid.Children.Clear();
                MainGrid.Children.Add(mainControl);
            }

        }


        public void Btn_findPassword_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(find);
        }

        public void Btn_findID_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(findID);
        }

        public void Btn_findPW_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(findPW);
        }

        //public void Btn_findPassword_Click(object sender, RoutedEventArgs e)
        //{
        //    MainGrid.Children.Clear();
        //    MainGrid.Children.Add(find);
        //}

        //public void Btn_findPassword_Click(object sender, RoutedEventArgs e)
        //{
        //    MainGrid.Children.Clear();
        //    MainGrid.Children.Add(find);
        //}



    }
}

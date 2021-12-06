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
        }

        public void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(mainControl);
        }

        public void Btn_register_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(registerPage);
        }

        public void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            
            if (mainControl.loginUserName.Text!= "")
            {
                int num = mainControl.loginUserName.Text.IndexOf("님");
                name = mainControl.loginUserName.Text.Substring(0,num);               
                MainGrid.Children.Clear();                
                MainGrid.Children.Add(userMenu);
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
            MainGrid.Children.Add(registerPage);


            //testWin = new TestWin();
            //testWin.Owner = this;
            //testWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;


            //this.Hide();
            //testWin.ShowDialog();
            //this.Show();
        }
    }
}

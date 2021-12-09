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
using System.Text.RegularExpressions;

namespace ImageProgram
{
    /// <summary>
    /// DeleteUser.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DeleteUser : UserControl
    {
        DB db = new DB();
        bool passwordCheck1 = false;
        string userId;
        List<User> userList = new List<User>();

        public DeleteUser()
        {
            InitializeComponent();
        }

        private void password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (pwCheck(password.Text) && password.Text != "")
                {
                    changedPassword.Text = $"입력하신 비밀번호는 {password.Text} 입니다.";
                    passwordCheck1 = true;
                }

                else
                {
                    changedPassword.Text = "비밀번호를 제대로 입력해주세요.";
                    password.Text = "";
                }
            }
        }

        public bool pwCheck(string pw)
        {
            Regex regex = new Regex("[^0-9a-z]+");
            Boolean boolean = regex.IsMatch(pw);
            Console.WriteLine(boolean);
            if (!boolean)
            {
                return true;
            }
            return false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            userId = loginWindow.CurrentUserID();
            if (passwordCheck1)
            {
                userList = db.userList(userList);
                foreach (User User in userList)
                {
                    if (User.UserPassword == password.Text)
                    {
                        MessageBox.Show($"{User.UserName}님이 회원탈퇴되었습니다.");
                        db.UserDelete(userId);
                        userList = db.userList(userList);
                        passwordCheck1 = false;
                        Window.GetWindow(this).Close();
                        //MainWindow mainWindow = new MainWindow();
                        //loginWindow.Close();

                    }

                    else
                    {
                        MessageBox.Show("비밀번호가 틀렸습니다. \r\n비밀번호를 다시 입력해주세요.");
                        passwordCheck1 = true;
                    }
                }
            }

            else
            {
                MessageBox.Show("비밀번호를 확인해주세요.");
            }
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            changedPassword.Text = "비밀번호를 입력해주세요.";
            password.Text = "";
            passwordCheck1 = false;
        }
    }
}

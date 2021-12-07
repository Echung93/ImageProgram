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
    /// findPW.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindPW : UserControl
    {
        DB db = new DB();
        List<User> userList;
        string userPW;

        public FindPW()
        {
            InitializeComponent();
        }

        private void findPW_Click(object sender, RoutedEventArgs e)
        {
            userList = db.userList(userList);
            bool idCheck = true;
            bool nameCheck = true;
            bool registrationNumberCheck = true;

            foreach (var user in userList)
            {
                if (user.UserId == userID.Text)
                {
                    idCheck = false;
                    if (user.UserName == name.Text)
                    {
                        nameCheck = false;
                        if (user.UserRegistrationNumber == registrationNumber.Text)
                        {
                            registrationNumberCheck = false;
                            userPW = user.UserPassword;
                            break;
                        }
                        break;
                    }
                    break;
                }
            }
            if (idCheck)
            {
                pw.Text = $"존재하지 않는 아이디 입니다. \r\n아이디를 다시 입력해주세요.";
            }

            else if (nameCheck)
            {
                pw.Text = $"이름을 잘못 입력하였습니다. \r\n이름을 다시 입력해주세요.";
            }

            else if (registrationNumberCheck)
            {
                pw.Text = $"주민번호를 잘못 입력하였습니다. \r\n주민번호를 다시 입력해주세요.";
            }

            else 
            {
                pw.Text = $"회원님의 비밀번호는 {userPW} 입니다.";
            }

        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            userID.Text = "";
            name.Text = "";
            registrationNumber.Text = "";
            pw.Text = "";
        }
        
        public bool idCheck(string id)
        {
            Regex regex = new Regex(@"^[0-9a-z]+");
            Boolean boolean = regex.IsMatch(id);
            if (boolean)
            {
                return true;
            }
            return false;
        }

        public bool nameCheck(string name)
        {
            Regex regex = new Regex(@"^[가-힣]{2,5}");
            Boolean boolean = regex.IsMatch(name);
            if (boolean)
            {
                return true;
            }
            return false;
        }     

        public bool registrationNumberCheck(string number)
        {
            Regex regex = new Regex(@"^[0-9][0-9][01][0-9][0123][0-9]-[1234][0-9]{6}");
            Boolean boolean = regex.IsMatch(number);
            if (boolean)
            {
                return true;
            }
            return false;
        }

        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (idCheck(userID.Text))
                {
                    userID.Text = userID.Text;
                    pw.Text = userID.Text;
                }

                else
                {
                    pw.Text = "아이디를 제대로 입력해주세요.";
                    userID.Text = "";
                }
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (nameCheck(name.Text))
                {
                    name.Text = name.Text.Replace(" ", "");
                    pw.Text = "";
                }

                else
                {
                    pw.Text = "이름을 제대로 입력해주세요.";
                    name.Text = "";
                }
            }
        }

        private void registrationNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (registrationNumberCheck(registrationNumber.Text))
                {
                    registrationNumber.Text = registrationNumber.Text;
                    pw.Text = "";
                }

                else
                {
                    pw.Text = "주민등록번호를 제대로 입력해주세요.";
                    registrationNumber.Text = "";
                }
            }
        }

        private void userID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void registrationNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

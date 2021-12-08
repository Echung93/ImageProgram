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
    /// findID.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindID : UserControl
    {
        DB db = new DB();
        List<User> userList;
        string userId;

        public FindID()
        {
            InitializeComponent();
        }

        private void findID_Click(object sender, RoutedEventArgs e)
        {
            userList = db.userList(userList);
            bool nameCheck = true;
            bool registrationNumberCheck = true;           
            
            foreach (var user in userList)
            {              
                if (user.UserName == name.Text)
                {
                    nameCheck = false;
                    if (user.UserRegistrationNumber == registrationNumber.Text)
                    {
                        registrationNumberCheck = false;
                        userId = user.UserId;
                        break;
                    }                    
                    break;
                }
            }

            if (!nameCheck && !registrationNumberCheck)
            {
                id.Text = $"회원님의 아이디는 {userId} 입니다.";
                
            }

            else if (!nameCheck)
            {
                id.Text = $"주민번호가 틀렸습니다. \r\n주민번호를 다시 입력해주세요.";
            }        
            
            else
            {
                id.Text = $"존재하지 않는 회원입니다. \r\n회원가입을 해주세요.";
            }
        }

        private void findPW_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            registrationNumber.Text = "";
            id.Text = "";
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            registrationNumber.Text = "";
            id.Text = "";
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.OemSemicolon || e.Key == Key.OemPeriod || e.Key == Key.OemMinus || e.Key == Key.OemQuestion || e.Key == Key.OemQuotes || e.Key == Key.OemPlus || e.Key == Key.OemCloseBrackets || e.Key == Key.OemOpenBrackets || e.Key == Key.OemComma || e.Key == Key.OemTilde)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (nameCheck(name.Text))
                {
                    name.Text = name.Text.Replace(" ", "");
                    id.Text = "";
                }

                else
                {
                    id.Text = "이름을 제대로 입력해주세요.";
                    name.Text = "";
                }
            }
        }

        private void registrationNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.OemSemicolon || e.Key == Key.OemPeriod || e.Key == Key.OemQuestion || e.Key == Key.OemQuotes || e.Key == Key.OemPlus || e.Key == Key.OemCloseBrackets || e.Key == Key.OemOpenBrackets || e.Key == Key.OemComma || e.Key == Key.OemTilde)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (registrationNumberCheck(registrationNumber.Text))
                {
                    registrationNumber.Text = registrationNumber.Text;
                    id.Text = "";
                }

                else
                {
                    id.Text = "주민등록번호를 제대로 입력해주세요.";
                    registrationNumber.Text = "";
                }
            }
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
            Regex regex = new Regex(@"^[0-9][0-9][01][0-9][0123][0-9]-[1234][0-9]{0,14}");
            Boolean boolean = regex.IsMatch(number);
            if (boolean)
            {
                return true;
            }
            return false;
        }

    }
}

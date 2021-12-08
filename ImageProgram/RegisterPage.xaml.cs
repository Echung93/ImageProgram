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
    /// RegisterPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RegisterPage : UserControl
    {
        DB db = new DB();
        List<User> userList = new List<User>();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userList = db.userList(userList);
            bool nameCheck = true;
            bool phoneNumberCheck = true;
            bool registrationNumberCheck = true;
            bool emailCheck = true;
            bool idCheck = true;

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].UserName == name.Text)
                {
                    nameCheck = false;
                }

                if (userList[i].UserPhoneNumber == phoneNumber.Text)
                    phoneNumberCheck = false;

                if (userList[i].UserRegistrationNumber == registrationNumber.Text)
                    registrationNumberCheck = false;

                if (userList[i].UserEmail == email.Text)
                    emailCheck = false;

                if (userList[i].UserId == id.Text)
                    idCheck = false;
            }

            if (!nameCheck)
            {
                MessageBox.Show("등록된 회원 입니다.");
            }

            else if (!phoneNumberCheck)
            {
                MessageBox.Show("등록된 핸드폰 번호 입니다.");
            }

            else if (!registrationNumberCheck)
            {
                MessageBox.Show("등록된 주민번호 입니다.");
            }

            else if (!emailCheck)
            {
                MessageBox.Show("등록된 이메일 입니다.");
            }

            else if (!idCheck)
            {
                MessageBox.Show("등록된 아이디 입니다.");
            }

            else
            {
                MessageBox.Show("회원가입 완료!");
            }

        }

        public bool nameCheck1(string name)
        {
            Regex regex = new Regex("[^가-힣]");
            Boolean boolean = regex.IsMatch(name);
            if (!boolean)
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

        public bool addressCheck(string address)
        {
            Regex regex;
            if (address.Contains("면") || address.Contains("읍") || address.Contains("동"))
            {
                regex = new Regex(@"^([가-힣]+)도([가-힣]+)시([가-힣0-9\-]+)(면|동|읍|로|길)([가-힣0-9]+)(로)([가-힣0-9\-]+)$");
            }

            else
            {
                regex = new Regex(@"^([가-힣]+)도([가-힣]+)시([가-힣0-9\-]+)(로|길)([가-힣0-9\-]+)$");
            }
            
            Boolean boolean = regex.IsMatch(address);
            if (boolean)
            {
                return true;
            }
            return false;
        }

        public bool phoneNumberCheck(string number)
        {
            Regex regex = new Regex(@"010-[0-9]{4}-[0-9]{4}$");
            Boolean boolean = regex.IsMatch(number);
            if (boolean)
            {
                return true;
            }
            return false;
        }

        public bool emailCheck(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w]+)((\.(\w){2,3})+)$");          
            Boolean boolean = regex.IsMatch(email);
            if (boolean)
            {
                return true;
            }
            return false;
        }

        public bool idCheck(string id)
        {
            Regex regex = new Regex("[^0-9a-z]");
            Boolean boolean = regex.IsMatch(id);
            if (!boolean)
            {
                return true;
            }
            return false;
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

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (nameCheck1(name.Text) && name.Text !="")
                {
                    name.Text = name.Text.Replace(" ", "");
                    name1.Text = "";
                }

                else
                {
                    name1.Text = "이름을 제대로 입력해주세요.";
                    name.Text = "";
                }
            }
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
           {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (addressCheck(address.Text) && address.Text != "")
                {
                    address.Text = address.Text;
                    address1.Text = "";
                }

                else
                {
                    address1.Text = "주소를 제대로 입력해주세요.";
                    address.Text = "";
                }
            }
        }

        private void registrationNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (registrationNumberCheck(registrationNumber.Text) && registrationNumber.Text != "")
                {
                    registrationNumber.Text = registrationNumber.Text;
                    registrationNumber1.Text = "";
                }

                else
                {
                    registrationNumber1.Text = "주민등록번호를 제대로 입력해주세요.";
                    registrationNumber.Text = "";
                }
            }
        }

        private void phoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (phoneNumberCheck(phoneNumber.Text) && phoneNumber.Text != "")
                {
                    phoneNumber.Text = phoneNumber.Text;
                    phoneNumber1.Text = "";
                }
                else
                {
                    phoneNumber.Text = "";
                    phoneNumber1.Text = "전화번호를 제대로 입력해주세요. ('-' 포함)";
                }

            }
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (emailCheck(email.Text) && email.Text != "")
                {
                    email.Text = email.Text;
                    email1.Text = "";
                }

                else
                {
                    email1.Text = "이메일을 제대로 입력해주세요.";
                    email.Text = "";
                }
            }
        }

        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (idCheck(id.Text) && id.Text != "")
                {
                    id.Text = id.Text;
                    id1.Text = id.Text;
                }

                else
                {
                    id1.Text = "아이디를 제대로 입력해주세요.";
                    id.Text = "";
                }
            }
        }

        private void pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (pwCheck(pw.Text) && pw.Text != "")
                {
                    pw1.Text = pw.Text;
                }

                else
                {
                    pw1.Text = "비밀번호를 제대로 입력해주세요.";
                    pw.Text = "";
                }
            }
        }
    }
}



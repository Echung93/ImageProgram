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
        public bool nameCheck1 = true;
        public bool phoneNumberCheck1 = true;
        public bool registrationNumberCheck1 = true;
        public bool idCheck1 = true;

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || name1.Text != "")
            {
                MessageBox.Show("이름을 제대로 입력해주세요!");
            }

            else if (registrationNumber.Text == "" || registrationNumber1.Text != "")
            {
                MessageBox.Show("주민번호를 제대로 입력해주세요!");
            }

            else if (address.Text == "" || address1.Text != "")
            {
                MessageBox.Show("주소를 제대로 입력해주세요!");
            }

            else if (phoneNumber.Text == "" || phoneNumber1.Text != "")
            {
                MessageBox.Show("전화번호를 제대로 입력해주세요!");
            }

            else if (email.Text == "" || email1.Text != "")
            {
                MessageBox.Show("이메일을 제대로 입력해주세요!");
            }

            else if (id.Text == "" || id1.Text != "")
            {
                MessageBox.Show("아이디를 제대로 입력해주세요!");
            }

            else if (pw.Text == "" || pw1.Text != "")
            {
                MessageBox.Show("비밀번호를 제대로 입력해주세요!");
            }

            else if (nameCheck1)
            {
                MessageBox.Show("이름 중복 확인을 해주세요.");
            }

            else if (registrationNumberCheck1)
            {
                MessageBox.Show("주민번호 중복 확인을 해주세요.");
            }

            else if (phoneNumberCheck1)
            {
                MessageBox.Show("전화번호 중복 확인을 해주세요.!");
            }

            else if (idCheck1)
            {
                MessageBox.Show("아이디 중복 확인을 해주세요.");
            }

            else
            {
                MessageBox.Show("회원가입 완료!");
                db.UserSave(id.Text, name.Text, pw.Text, address.Text, phoneNumber.Text, registrationNumber.Text, email.Text);
            }
        }

        public bool nameCheck(string name)
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
                regex = new Regex(@"^([가-힣]+)도([가-힣]+)시([가-힣0-9\-]+)(면|동|읍|로|길)([가-힣0-9]+)(로)([가-힣0-9\-]+)([가-힣0-9]+)$");
            }

            else
            {
                regex = new Regex(@"^([가-힣]+)도([가-힣]+)시([가-힣0-9\-]+)(로|길)([가-힣0-9\-]+)([가-힣0-9]+)$");
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
                if (nameCheck(name.Text) && name.Text != "")
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
                    id1.Text = "";
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
                    pw1.Text = "";
                }

                else
                {
                    pw1.Text = "비밀번호를 제대로 입력해주세요.";
                    pw.Text = "";
                }
            }
        }

        private void name_rnCheck_Button_Click(object sender, RoutedEventArgs e)
        {
            userList = db.userList(userList);
            nameCheck1 = true;
            registrationNumberCheck1 = true;

            if (registrationNumber1.Text == "" && name1.Text == "")
            {
                foreach (User user in userList)
                {
                    if (user.UserRegistrationNumber == registrationNumber.Text)
                    {
                        registrationNumberCheck1 = false;
                        if (user.UserName == name.Text)
                        {
                            nameCheck1 = false;

                        }
                    }
                }

                if (!registrationNumberCheck1)
                {
                    MessageBox.Show("이미 가입된 주민번호입니다.");
                    registrationNumber1.Text = "이미 가입된 주민번호입니다.";
                    registrationNumber.Text = "";
                }

                else if (nameCheck1)
                {
                    if (name.Text == "")
                    {
                        MessageBox.Show("이름을 입력해주세요.");
                        nameCheck1 = true;
                    }

                    else if (registrationNumberCheck1)
                    {
                        if (registrationNumber.Text == "")
                        {
                            MessageBox.Show("주민번호를 입력해주세요.");
                            registrationNumberCheck1 = true;
                        }
                    }

                }

                else if (!nameCheck1 && !registrationNumberCheck1)
                {
                    MessageBox.Show("이미 등록된 회원입니다.");
                    name.Text = "";
                    nameCheck1 = true;
                    registrationNumberCheck1 = true;
                }

                if (nameCheck1 && registrationNumberCheck1)
                {
                    MessageBox.Show("회원 가입이 가능합니다.");
                    nameCheck1 = false;
                    registrationNumberCheck1 = false;
                }
            }
            else
            {
                MessageBox.Show("이름 및 주민 번호에서 중복확인이 안되었습니다.\r\n 다시 시도해주세요");
                nameCheck1 = true;
                registrationNumberCheck1 = true;
            }
        }

        private void pnCheck_Button_Click(object sender, RoutedEventArgs e)
        {
            userList = db.userList(userList);

            if (phoneNumber1.Text == "")
            {
                foreach (User user in userList)
                {
                    if (user.UserPhoneNumber == phoneNumber.Text)
                    {
                        phoneNumberCheck1 = false;
                    }
                }

                if (phoneNumberCheck1)
                {
                    if (phoneNumber.Text == "")
                    {
                        MessageBox.Show("전화번호를 입력해주세요.");
                        phoneNumberCheck1 = true;
                    }

                    else
                    {
                        MessageBox.Show("전화번호 인증 완료");
                        phoneNumberCheck1 = false;
                    }
                }

                else
                {
                    MessageBox.Show("이미 가입된 전화번호 입니다.");
                    phoneNumber1.Text = "이미 가입된 전화번호 입니다.";
                    phoneNumber.Text = "";
                    phoneNumberCheck1 = true;
                }
            }

            else
            {
                MessageBox.Show("전화번호에서 중복확인이 안되었습니다.\r\n 다시 시도해주세요");
                nameCheck1 = true;
                registrationNumberCheck1 = true;
            }
        }

        private void idCheck_Button_Click(object sender, RoutedEventArgs e)
        {
            idCheck1 = true;
            userList = db.userList(userList);

            if (id1.Text == "")
            {
                foreach (User user in userList)
                {
                    if (user.UserId == id.Text)
                    {
                        idCheck1 = false;
                    }
                }

                if (idCheck1)
                {
                    if (id.Text == "")
                    {
                        MessageBox.Show("아이디를 입력해주세요.");
                        idCheck1 = true;
                    }

                    else
                    {
                        MessageBox.Show("사용 가능한 아이디 입니다.");
                        idCheck1 = false;
                    }
                }

                else
                {
                    MessageBox.Show("이미 가입된 아이디 입니다.");
                    id1.Text = "이미 가입된 아이디 입니다.";
                    id.Text = "";
                    idCheck1 = true;
                }
            }

            else
            {
                MessageBox.Show("아이디가 중복확인이 안되었습니다.\r\n 다시 시도해주세요");
                idCheck1 = true;
            }

        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            name1.Text = "이름을 입력해주세요.";

            registrationNumber.Text = "";
            registrationNumber1.Text = "주민번호를 입력해주세요.(' - '포함)";

            address.Text = "";
            address1.Text = "주소를 입력해주세요.";

            phoneNumber.Text = "";
            phoneNumber1.Text = "핸드폰 번호를 입력해주세요.(' - '포함)";

            email.Text = "";
            email1.Text = "이메일을 입력해주세요.";

            id.Text = "";
            id1.Text = "아이디를 입력해주세요.";

            pw.Text = "";
            pw1.Text = "패스워드를 입력해주세요.";
        }
    }
}



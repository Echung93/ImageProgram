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
    /// PhoneNumberAlter.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PhoneNumberAlter : UserControl
    {
        LoginWindow loginWindow = new LoginWindow();
        DB db = new DB();
        List<User> userList;
        string userId = "kty309";
        
        bool phoneNumberCheck1 = false;

        public PhoneNumberAlter()
        {
            InitializeComponent();
        }

        private void phoneNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (phoneNumberCheck(phoneNumber.Text) && phoneNumber.Text != "")
                {
                    changedPhoneNumber.Text = $"입력하신 전화번호는 {phoneNumber.Text} 입니다.";
                    phoneNumberCheck1 = true;
                }
                else
                {
                    phoneNumber.Text = "";
                    changedPhoneNumber.Text = "전화번호를 제대로 입력해주세요. ('-' 포함)";
                }

            }
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

        private void alter_Click(object sender, RoutedEventArgs e)
        {
            userId = loginWindow.CurrentUserID();
            if (phoneNumberCheck1)
            {
                userList = db.userList(userList);
                foreach (User User in userList)
                {
                    if (User.UserPhoneNumber == phoneNumber.Text)
                    {
                        MessageBox.Show("기존의 전화번호와 같은 비밀번호 입니다. \r\n전화번호를 다시 입력해주세요.");
                    }

                    else
                    {
                        MessageBox.Show($"{phoneNumber.Text}로 전화번호를 변경하였습니다.");
                        db.UserUpdate(userId, phoneNumber.Text, null, null);
                        userList = db.userList(userList);
                        phoneNumberCheck1 = false;
                    }
                }
            }

            else
            {
                MessageBox.Show("변경할 전화번호를 입력해주세요.");
            }
        }

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            changedPhoneNumber.Text = "변경할 전화번호를 입력해주세요. (' - ' 포함)";
            phoneNumber.Text = "";
            phoneNumberCheck1 = false;            
        }
    }
}

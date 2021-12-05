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
            bool nameCheck = true ;
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

                if (userList[i].UserId ==id.Text)
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
    }
}



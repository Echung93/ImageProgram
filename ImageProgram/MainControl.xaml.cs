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
    /// MainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public partial class MainControl : UserControl
    {
        RegisterPage registerPage = new RegisterPage();
        UserMenu usermenu = new UserMenu();
        DB db = new DB();
        
        
        List<User> userList = new List<User>();
        List<Log> logList = new List<Log>();

        string id;
        string pw;
        public static string loginUser;

        public MainControl()
        {
            InitializeComponent();
        }
        public void Btn_register_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            //string action = "로그인";
            //bool idCheck = false;
            //bool pwCheck = false;
            //userList = db.userList(userList);
            //logList = db.logList(logList);
            //id = IDInput.Text;
            //pw = PWInput.Password;
            //for (int i = 0; i < userList.Count; i++)
            //{
            //    if (userList[i].UserId == (id))
            //    {
            //        if (userList[i].UserPassword == (pw))
            //        {
            //            int count = logList.Count;
            //            Console.Write("        로그인 성공");
            //            string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            //            db.LogSave(count + 1, userList[i].UserName, time, action, null);
            //            pwCheck = true;
            //            loginUser = userList[i].UserName;
            //            loginUserName.Text = $"{loginUser}님이 로그인 하셨습니다.";
            //            usermenu.loginUser.Text = $"{loginUser}님 환영합니다.";                       
            //        }
            //        idCheck = true;
            //    }
            //}

            //if (!idCheck)
            //{
            //    MessageBox.Show("존재하지 않는 회원입니다. 다시 로그인 해주세요.");
            //    IDInput.Text = "";
            //    PWInput.Clear();
            //}

            //else if (!pwCheck)
            //{
            //    MessageBox.Show("틀린 비밀번호 입니다. 비밀번호를 다시 입력해주세요.");
            //    IDInput.Text = "";
            //    PWInput.Clear();
            //}
            //else
            //{
            //    MessageBox.Show("로그인 성공");

            //}
        }

        public string login ()
        {
            string action = "로그인";
            bool idCheck = false;
            bool pwCheck = false;
            userList = db.userList(userList);
            logList = db.logList(logList);
            id = IDInput.Text;
            pw = PWInput.Password;
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].UserId == (id))
                {
                    if (userList[i].UserPassword == (pw))
                    {
                        int count = logList.Count;
                        Console.Write("        로그인 성공");
                        string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                        db.LogSave(count + 1, userList[i].UserName, time, action, null);
                        pwCheck = true;
                        loginUser = userList[i].UserName;
                        loginUserName.Text = $"{loginUser}님이 로그인 하셨습니다.";
                        usermenu.loginUser.Text = $"{loginUser}님 환영합니다.";
                    }
                    idCheck = true;
                }
            }

            if (!idCheck)
            {
                MessageBox.Show("존재하지 않는 회원입니다. 다시 로그인 해주세요.");
                IDInput.Text = "";
                PWInput.Clear();
            }

            else if (!pwCheck)
            {
                MessageBox.Show("틀린 비밀번호 입니다. 비밀번호를 다시 입력해주세요.");
                IDInput.Text = "";
                PWInput.Clear();
            }
            else
            {
                MessageBox.Show("로그인 성공");                
            }

            return loginUser;
        }


        private void Btn_findPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IDInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9a-z]+");
            Boolean boolean = regex.IsMatch(e.Text);

            if (!boolean)
            {
                IDInput.Text = "";
            }
        }

        private void IDInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.OemSemicolon || e.Key == Key.OemPeriod || e.Key == Key.OemMinus || e.Key == Key.OemQuestion || e.Key == Key.OemQuotes || e.Key == Key.OemPlus || e.Key == Key.OemCloseBrackets || e.Key == Key.OemOpenBrackets || e.Key == Key.OemComma || e.Key == Key.OemTilde)
            {
                e.Handled = true;
                //e.Handled = false일 때 실행!
            }

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (idCheck(IDInput.Text))
                {
                    IDInput.Text = IDInput.Text;
                }

                else
                {
                    IDInput.Text = "";
                }
            }
        }
        private void Password_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PWInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
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

    }
}

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
using System.Windows.Shapes;

namespace ImageProgram
{
    /// <summary>
    /// loginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserMenu userMenu = new UserMenu();
        MainControl mainControl = new MainControl();
        AddressAlter addressAlter = new AddressAlter();
        PasswordAlter passwordAlter = new PasswordAlter();
        PhoneNumberAlter phoneNumberAlter = new PhoneNumberAlter();
        ViewUserInformation viewUserInformation = new ViewUserInformation();
        ModifyUserInformation modifyUserInformation = new ModifyUserInformation();
        SearchImage searchImage = new SearchImage();
        DeleteUser deleteUser = new DeleteUser();
        RecentSearchList recentSearchList = new RecentSearchList();
        DB db = new DB();

        List<User> userList = new List<User>();
        List<Log> logList = new List<Log>();

        public static string loginID;
        public static string currentUser;
        string input;

        public LoginWindow()
        {
            InitializeComponent();
            loginGrid.Children.Add(userMenu);
            loginID = mainControl.CurrentUser();
            userMenu.loginUser.Text = $"{loginID}님 환영합니다.";
            modifyUserInformation.Btn_back.Click += Btn_back_Click;
            modifyUserInformation.Btn_userInformation.Click += Btn_userInformation_Click;
            modifyUserInformation.Btn_addressAlter.Click += Btn_addressAlter_Click;
            modifyUserInformation.Btn_passwordAlter.Click += Btn_passwordAlter_Click;
            modifyUserInformation.Btn_phoneNumberAlter.Click += Btn_phoneNumberAlter_Click;
            searchImage.btn_back.Click += Btn_back_Click;
            addressAlter.Btn_back.Click += Btn_back_Click1;
            passwordAlter.Btn_back.Click += Btn_back_Click1;
            phoneNumberAlter.Btn_back.Click += Btn_back_Click1;
            viewUserInformation.Btn_back.Click += Btn_back_Click1;
            deleteUser.Btn_back.Click += Btn_back_Click;
            userMenu.logout.Click += Btn_logout_Click;
            userMenu.userDelete.Click += Btn_userDelete_Click;
            userMenu.userInformationAlter.Click += Btn_userInformationAlter_Click;
            userMenu.searchImage.Click += Btn_searchImage_Click;
            recentSearchList.Btn_back.Click += Btn_back_Click2;
            searchImage.btn_viewLog.Click += Btn_viewLoig_Click;
        }

        public string CurrentUserID()
        {
            currentUser = loginID;
            return currentUser;
        }

        public void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Btn_userDelete_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(deleteUser);
        }

        public void Btn_userInformationAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(modifyUserInformation);
        }

        public void Btn_searchImage_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(searchImage);
        }

        public void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(userMenu);
        }

        public void Btn_back_Click1(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(modifyUserInformation);
        }

        public void Btn_back_Click2(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(searchImage);
        }

        public void Btn_userInformation_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            userList = db.userList(userList);
            foreach (User user in userList)
            {
                if (user.UserId == loginID)
                {
                    viewUserInformation.name.Text = user.UserName;
                    viewUserInformation.registrationNumber.Text = user.UserRegistrationNumber;
                    viewUserInformation.address.Text = user.UserAddress;
                    viewUserInformation.phoneNumber.Text = user.UserPhoneNumber;
                    viewUserInformation.email.Text = user.UserEmail;
                }
            }
            loginGrid.Children.Add(viewUserInformation);
        }

        public void Btn_passwordAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(passwordAlter);
        }

        public void Btn_addressAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(addressAlter);
        }
        public void Btn_phoneNumberAlter_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            loginGrid.Children.Add(phoneNumberAlter);
        }
        
        public void Btn_viewLoig_Click(object sender, RoutedEventArgs e)
        {
            loginGrid.Children.Clear();
            logList = db.logList(logList);
            
            foreach (Log log in logList)
            {
                if (log.SearchName !="")
                {
                    input += $"{log.UserName}님이 {log.Time}초에 \r\n" +
                        $"검색어 {log.SearchName }을(를) {log.Action}하였습니다.\r\n";
                }
                
                else
                {
                    input +=$"{log.UserName}님이 {log.Time}에 {log.Action}하였습니다.\r\n";
                }
            }
            recentSearchList.searchList.Items.Add(input);
            loginGrid.Children.Add(recentSearchList);
        }

    }
}

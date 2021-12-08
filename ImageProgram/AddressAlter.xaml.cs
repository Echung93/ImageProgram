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
    /// AddressAlter.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddressAlter : UserControl
    {
        DB db = new DB();
        List<User> userList;
        string userId = "kty309";
        bool addressCheck1 = false;

        public AddressAlter()
        {
            InitializeComponent();
        }

        private void alter_Click(object sender, RoutedEventArgs e)
        {
            if (addressCheck1)
            {
                userList = db.userList(userList);
                foreach (User User in userList)
                {
                    if (User.UserAddress == address.Text)
                    {
                        MessageBox.Show("기존의 주소와 같은 주소 입니다. \r\n주소를 다시 입력해주세요.");
                    }

                    else
                    {
                        MessageBox.Show($"{address.Text}로 주소를 변경하였습니다.");
                        db.UserUpdate(userId, null, address.Text, null);
                        userList = db.userList(userList);
                        addressCheck1 = false;
                    }
                }
            }

            else
            {
                MessageBox.Show("변경할 주소를 입력해주세요.");
            }
        }

        private void address_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (addressCheck(address.Text) && address.Text != "")
                {
                    address.Text = address.Text;
                    changedAddress.Text = "";
                    addressCheck1 = true;
                }

                else
                {
                    changedAddress.Text = "주소를 제대로 입력해주세요.";
                    address.Text = "";
                }
            }
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

        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            changedAddress.Text = "변경할 주소를 입력해주세요.(도로명주소로)";
            address.Text = "";
            addressCheck1 = false;
        }
    }
}

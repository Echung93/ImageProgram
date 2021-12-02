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
        public MainControl()
        {
            InitializeComponent();
            statusText.Text = "패스워드를 입력해주세요.";
            IDInput.Text = "아이디를 입력해주세요.";
            this.IDInput.PreviewTextInput += Input_TextInput;
            this.IDInput.TextChanged += IDInput_TextChanged;


        }
        public string id { get; set; }
        public string password { get; set; }

        public void btn_recent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_image_Click(object sender, RoutedEventArgs e)
        {

            Upload upload2 = new Upload()
            {
                id = IDInput.Text,
                password = PWInput.Password
            };

        }


        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PWInput.Password != "")
            {
                PWInput.Password += e.Handled = !IsNumeric(e.Text);
            }

            else
            {
                statusText.Text = "패스워드를 입력해주세요.";
            }
        }

        private void Input_TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void IDInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool IsNumeric(string source)
        {
            Regex regex = new Regex("[a-zA-Z_0-9]");

            return !regex.IsMatch(source);
        }
    }
}

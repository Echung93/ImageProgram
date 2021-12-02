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
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MainControl mainControl = new MainControl();
        UserControl1 userControl1 = new UserControl1();
        TestPage testPage = new TestPage();
        Window testWin;

        public MainWindow()
        {
            InitializeComponent();
            MainGrid.Children.Add(mainControl);

            mainControl.btn_image.Click += new RoutedEventHandler(btn_image_Click);
            mainControl.btn_recent.Click += btn_recent_Click;
            mainControl.btn_test.Click += btn_test_Click;
            userControl1.btn_back.Click += btn_back_Click;
        }

        public void btn_back_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(mainControl);
        }

        public void btn_recent_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(userControl1);
        }

        public void btn_image_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(userControl1);
            userControl1.wp.Children.Clear();

            // 이미지 추가
            ImageItem image = new ImageItem();
            ImageItem image1 = new ImageItem();
            userControl1.wp.Children.Add(image);
            userControl1.wp.Children.Add(image1);
        }


        public void btn_test_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(testPage);


            //testWin = new TestWin();
            //testWin.Owner = this;
            //testWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;


            //this.Hide();
            //testWin.ShowDialog();
            //this.Show();
        }
    }
}

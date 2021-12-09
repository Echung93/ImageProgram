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
    /// SearchImage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchImage : UserControl
    {
        API api = new API();
        DB db = new DB();
        List<ImageVO> imageList;
        public static string userId;

        //ImageItem imageItem = new ImageItem();

        public SearchImage()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            clickImage.Source = null;

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            imageList = new List<ImageVO>();
            lbx.Items.Clear();
            List<Log> logList = new List<Log>();
            List<User> userList = new List<User>();
            lbx.SelectionChanged += new SelectionChangedEventHandler(list_SelectionChanged);
            clickImage.Source = null;
            string action = "검색";

            if (searchBox.Text == "")
            {
                MessageBox.Show("검색하고 싶은 검색어를 입력해주세요.");
            }

            else
            {

                imageList = api.searchImage(searchBox.Text);


                foreach (ImageVO image in imageList)
                {
                    Uri uri = new Uri(image.Thumbnail);
                    BitmapImage bitmap = new BitmapImage(uri);
                    Image viewImage = new Image();
                    viewImage.Source = bitmap;
                    lbx.Items.Add(viewImage);
                }


                LoginWindow loginWindow = new LoginWindow();
                userId = loginWindow.CurrentUserID();
                userList = db.userList(userList);
                logList = db.logList(logList);

                foreach (User user in userList)
                {
                    if (user.UserId == userId)
                    {
                        foreach (Log log in logList)
                        {
                            if (log.SearchName == searchBox.Text)
                            {
                                db.LogDelete(searchBox.Text);
                                logList = db.logList(logList);
                            }
                        }
                    }
                    string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    db.LogSave(user.UserName, time, action, searchBox.Text);
                }
            }
        }

        public void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("selected index = " + lbx.SelectedIndex);

            if (lbx.Items.Count != 0)
            {
                int a = lbx.SelectedIndex;
                imageList = api.searchImage(searchBox.Text);
                Uri uri = new Uri(imageList[a].Link);
                BitmapImage bitmap = new BitmapImage(uri);
                clickImage.Source = bitmap;
            }
        }

    }
}

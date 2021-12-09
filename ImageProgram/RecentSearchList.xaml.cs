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
    /// RecentSearchList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecentSearchList : UserControl
    {
        public RecentSearchList()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            db.searchListDelete();
            MessageBox.Show("기록 삭제 완료");
        }
    }
}

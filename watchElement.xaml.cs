using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace testImageApp
{
    /// <summary>
    /// Логика взаимодействия для watchElement.xaml
    /// </summary>
    public partial class watchElement : Page
    {
        ImageEntities imageEnt = new ImageEntities();
        public watchElement(imageTable p)
        {
            InitializeComponent();
            imageEnt.imageTable.Load();
            imageEnt.imagePathTable.Load();
            watchInfo(p);
        }     
       
        void watchInfo(imageTable p)
        {
            idTB.Text = Convert.ToString(p.id);
            nameTB.Text = p.name;
            var photo = from data in imageEnt.imageTable
                        join photoPath in imageEnt.imagePathTable
                        on data.id equals photoPath.codeTable
                        where photoPath.codeTable == p.id
                        select new { photoPath.img };
            checkPhoto.ItemsSource = photo.ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigateClass.navigationProgramm.CanGoBack)
                NavigateClass.navigationProgramm.GoBack();
        }

        //private void checkPhoto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //   var watch = checkPhoto.SelectedItem  as imagePathTable;
        //    new PhotoWindow(watch.img).Show();
        //}        

        private void imageHome_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var watch = checkPhoto.SelectedItem as imagePathTable;
            new PhotoWindow(watch).Show();
        }
    }
}

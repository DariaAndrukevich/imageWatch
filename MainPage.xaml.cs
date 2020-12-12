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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ImageEntities imageEnt = new ImageEntities();
        public MainPage()
        {
            InitializeComponent();
            outputImage();
        }
        public void outputImage()
        {
            imageEnt.imageTable.Load();
            dataList.ItemsSource = imageEnt.imageTable.Local.ToBindingList();

        }
        private void deleteRow_Click(object sender, RoutedEventArgs e) // Удаление выбранной записи
        {
            var removeRow = dataList.SelectedItem as imageTable;
            // если запись не выбрана, удаление не произойдет
            if (removeRow == null)
            {
                MessageBox.Show("Выберите, что нужно удалить!");
                return;
            }
            try
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Предупреждение об удалении", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        imageEnt.imageTable.Remove(removeRow);
                        imageEnt.SaveChanges();
                        MessageBox.Show("Успешное удаление записи.");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления.");
            }
        }

        private void addNewRow_Click(object sender, RoutedEventArgs e)
        {

        }
        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            imageTable p = (imageTable)dataList.SelectedItem;
            NavigateClass.navigationProgramm.Navigate(new watchElement(p));

        }
    }
}


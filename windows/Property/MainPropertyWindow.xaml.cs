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
using rentPrac1.DataAccess;
using rentPrac1.Models;
using rentPrac1.windows.Clients;

namespace rentPrac1.windows.Property
{
    /// <summary>
    /// Логика взаимодействия для MainPropertyWindow.xaml
    /// </summary>
    public partial class MainPropertyWindow : Window
    {
        private readonly AppDbContext context = new AppDbContext();

        public MainPropertyWindow()
        {
            InitializeComponent();
            dataList.ItemsSource = context.Properties.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new AddProperty();
            window1.Show();
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window1 = new MainWindow();
            window1.Show();
            this.Close();
        }

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            var property = dataList.SelectedItem as Models.Property;
            if(property != null)
            {
            var window2 = new EditProperties(context, property);
            window2.Show();
            }
            
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            dataList.ItemsSource = context.Properties.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window2 = new TypesOfProperty();
            window2.Show();

        }
    }
}

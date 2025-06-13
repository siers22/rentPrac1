using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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

namespace rentPrac1.windows.Property
{
    /// <summary>
    /// Логика взаимодействия для TypesOfProperty.xaml
    /// </summary>
    public partial class TypesOfProperty : Window
    {
        private readonly AppDbContext context = new AppDbContext();
        public TypesOfProperty()
        {
            InitializeComponent();
            datalist.ItemsSource = context.PropertyTypes.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window2 = new AddTypeOfProperty();
            window2.Show();

        }

        private void datalist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = datalist.SelectedItem as PropertyType;
            if (type != null)
            {
                var window1 = new EditTypesOfProperty(context, type);
                window1.Show();
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            datalist.ItemsSource = context.PropertyTypes.ToList();
        }

        private void datalist_MouseEnter(object sender, MouseEventArgs e)
        {
            datalist.ItemsSource = context.PropertyTypes.ToList();
        }
    }
}

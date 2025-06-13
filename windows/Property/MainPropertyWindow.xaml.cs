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

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            dataList.ItemsSource = context.Properties.ToList();
        }
    }
}

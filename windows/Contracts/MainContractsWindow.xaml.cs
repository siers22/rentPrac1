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
using rentPrac1.windows.Property;

namespace rentPrac1.windows.Contracts
{
    /// <summary>
    /// Логика взаимодействия для MainContractsWindow.xaml
    /// </summary>
    public partial class MainContractsWindow : Window
    {
        private readonly AppDbContext context = new AppDbContext();
        public MainContractsWindow()
        {
            InitializeComponent();
            dataList.ItemsSource = context.Contracts.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new AddContractWindow();
            window1.Show();

        }

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var contract = dataList.SelectedItem as Models.Contract;
            if (contract != null)
            {
                var window2 = new EditContractWindow(context, contract);
                window2.Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataList_MouseEnter(object sender, MouseEventArgs e)
        {
            dataList.ItemsSource = context.Contracts.ToList();
        }
    }
}

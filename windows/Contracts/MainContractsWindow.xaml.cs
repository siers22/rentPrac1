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
    }
}

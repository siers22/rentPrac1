using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using rentPrac1.DataAccess;
using rentPrac1.Models;

namespace rentPrac1.windows.Contracts
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        private readonly AppDbContext context = new AppDbContext();
        public AddContractWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var newCotract = new Models.Contract { ClientId = Convert.ToInt32(clientInput.Text),
                PropertyId = Convert.ToInt32(propertyinput.Text),
                ContractStartDate = Convert.ToString(DateTime.Today),
                ContractEndDate = Convert.ToString(rentEndPicker.SelectedDate),
                RentTime = Convert.ToInt32(renttimeinput.Text)};
            context.Add(newCotract);
            context.SaveChanges();
            this.Close();
        }
    }
}

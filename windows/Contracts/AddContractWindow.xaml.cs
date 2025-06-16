using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
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
            FillCombobox();
        }
        public async void FillCombobox()
        {
            clientCB.ItemsSource = await context.Clients.AsNoTracking().ToListAsync();
            propCB.ItemsSource = await context.Properties.AsNoTracking().ToListAsync();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(renttimeinput.Text))
            {
                var newCotract = new Models.Contract { ClientId = (int)clientCB.SelectedValue,
                    PropertyId = (int)propCB.SelectedValue,
                    ContractStartDate = DateTime.Now.ToString().Remove(11), 
                    ContractEndDate = DateTime.Now.AddMonths(Convert.ToInt32(renttimeinput.Text)).ToString().Remove(11),
                    RentTime = Convert.ToInt32(renttimeinput.Text)};
                context.Add(newCotract);
                context.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Укажите время аренды");
            }
        }

        private void renttimeinput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}

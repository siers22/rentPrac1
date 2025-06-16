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
using Microsoft.IdentityModel.Tokens;
using rentPrac1.DataAccess;

namespace rentPrac1.windows.Contracts
{
    /// <summary>
    /// Логика взаимодействия для EditContractWindow.xaml
    /// </summary>
    public partial class EditContractWindow : Window
    {
        private readonly AppDbContext context;
        private readonly Models.Contract contract;


        public async void FillCombobox()
        {
            using var context1 = new AppDbContext();
            clientCB.ItemsSource = await context1.Clients.AsNoTracking().ToListAsync();
            propCB.ItemsSource = await context1.Properties.AsNoTracking().ToListAsync();
        }
        public EditContractWindow(AppDbContext context, Models.Contract contract)
        {
            InitializeComponent();
            FillCombobox();
            this.context = context;
            this.contract = contract;
            clientCB.SelectedValue = contract.ClientId;
            propCB.SelectedValue = contract.PropertyId;
            renttimeinput.Text = Convert.ToString(contract.RentTime);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(renttimeinput.Text))
            {
                contract.ClientId = (int)clientCB.SelectedValue;
                contract.PropertyId = (int)propCB.SelectedValue;
                contract.RentTime = Convert.ToInt32(renttimeinput.Text);
                string timestart = contract.ContractStartDate.ToString();
                var timestartD = DateTime.Parse(timestart);
                contract.ContractEndDate = timestartD.AddMonths(Convert.ToInt32(renttimeinput.Text)).ToString().Remove(11);
                context.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Укажите время аренды");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var contr = contract;
            if (contr != null)
            {
                context.Remove(contr);
                context.SaveChanges();
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void renttimeinput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}

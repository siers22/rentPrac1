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

        public EditContractWindow(AppDbContext context, Models.Contract contract)
        {
            InitializeComponent();
            this.context = context;
            this.contract = contract;
            clientInput.Text = Convert.ToString(contract.ClientId);
            propertyinput.Text = Convert.ToString(contract.PropertyId);
            renttimeinput.Text = Convert.ToString(contract.ClientId);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contract.ClientId = Convert.ToInt32(clientInput.Text);
            contract.PropertyId = Convert.ToInt32(propertyinput.Text);
            contract.RentTime = Convert.ToInt32(renttimeinput.Text);
            context.SaveChanges();
            this.Close();
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
    }
}

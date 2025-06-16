using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.EntityFrameworkCore;
using rentPrac1.DataAccess;
using rentPrac1.Models;
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
            FillGrid();
        }
        private void FillGrid()
        {
            dataList.ItemsSource = context.Contracts
                .Include(x => x.Client)
                .Include(x => x.Property)
                .Select(x => new ContractDto(x.Id, x.Client.Name, x.Property.Name, x.ContractStartDate, x.ContractEndDate, x.RentTime))
                .ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new AddContractWindow();
            window1.Show();

        }

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var contract = dataList.SelectedItem as Models.ContractDto;
            if (contract != null)
            {
                var contract1 = context.Contracts
                    .Where(c => c.Id == contract.Id)
                    .FirstOrDefault();
                if (contract1 != null)
                {
                    var window2 = new EditContractWindow(context, contract1);
                    window2.Show();
                }
            }
  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Client")
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == "Property")
            {
                e.Cancel = true;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var query = context.Contracts
                .Include(x => x.Client)
                .Include(x => x.Property)
                .Select(x => new ContractDto(x.Id, x.Client.Name, x.Property.Name, x.ContractStartDate, x.ContractEndDate, x.RentTime))
                .ToList()
                .AsQueryable();

            if (!string.IsNullOrEmpty(clientNameInput.Text))
            {
                query = query.Where(b => b.ClientName.Contains(clientNameInput.Text));
            }
            if (!string.IsNullOrEmpty(propertyNameInput.Text))
            {
                query = query.Where(b => b.PropertyName.Contains(propertyNameInput.Text));
            }
            

            var result = query.ToList();

            dataList.ItemsSource = result;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            clientNameInput.Clear();
            propertyNameInput.Clear();
            FillGrid();
        }
    }
}

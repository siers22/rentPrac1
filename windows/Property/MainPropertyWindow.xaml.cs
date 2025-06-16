using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
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
            FillGrid();
            propTypeCB.ItemsSource = context.PropertyTypes.ToList();
            propTypeCB.DisplayMemberPath = "Name";
        }
        private void FillGrid()
        {
            dataList.ItemsSource = context.Properties
                .Include(x => x.Type)
                .Select(x => new PropertyDto(x.Id, x.Name, x.Type.Name, x.Address, x.Price))
                .ToList();
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
            var property = dataList.SelectedItem as Models.PropertyDto;
            if (property != null) // Проверка до использования property.Id
            {
                var property1 = context.Properties
                    .Where(c => c.Id == property.Id)
                    .FirstOrDefault();
                if (property1 != null)
                {
                    var window2 = new EditProperties(context, property1);
                    window2.Show();
                }
            }

        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            FillGrid();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window2 = new TypesOfProperty();
            window2.Show();

        }
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Contracts")
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == "Type")
            {
                e.Cancel = true;
            }
        }

        

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = context.Properties
                .Include(x => x.Type)
                .Select(x => new PropertyDto(x.Id, x.Name, x.Type.Name, x.Address, x.Price))
                .ToList()
                .AsQueryable();

            if (!string.IsNullOrEmpty(propNameInput.Text))
            {
                query = query.Where(b => b.Nmae.Contains(propNameInput.Text));
            }
            if (!string.IsNullOrEmpty(addressInput.Text))
            {
                query = query.Where(b => b.address.Contains(addressInput.Text));
            }
            if(propTypeCB.SelectedItem != null)
            {
                query = query.Where(c => c.TypeName == propTypeCB.Text);
            }

            var result = query.ToList();

            dataList.ItemsSource = result;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            propNameInput.Clear();
            addressInput.Clear();
            propTypeCB.SelectedValue = null;
        }
    }
}

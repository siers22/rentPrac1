using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore.Diagnostics;
using rentPrac1.DataAccess;
using rentPrac1.Models;


namespace rentPrac1.windows.Property
{
    /// <summary>
    /// Логика взаимодействия для AddProperty.xaml
    /// </summary>
    public partial class AddProperty : Window
    {
        private readonly AppDbContext context = new AppDbContext();
        public AddProperty()
        {
            InitializeComponent();
            FillCombobox();
        }

        public async void FillCombobox()
        {
            typesInput.ItemsSource = await context.PropertyTypes.AsNoTracking().ToListAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            var newprop = new Models.Property { Name = nameInput.Text, Address = addresInput.Text, Price = Convert.ToInt32(priceInput.Text), TypeId = (int)typesInput.SelectedValue };
            context.Properties.Add(newprop);
            context.SaveChanges();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void priceInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
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

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using rentPrac1.DataAccess;

namespace rentPrac1.windows.Property
{
    /// <summary>
    /// Логика взаимодействия для EditProperties.xaml
    /// </summary>
    public partial class EditProperties : Window
    {
        private readonly AppDbContext context;
        private readonly Models.Property property;

        public EditProperties(AppDbContext context, Models.Property property)
        {
            InitializeComponent();
            try
            {
                if (property != null)
                {
                    this.context = context;
                    this.property = property;
                    nameinput.Text = property.Name;
                    addressInput.Text = property.Address;
                    priceInput.Text = Convert.ToString(property.Price);

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            property.Name = nameinput.Text;
            property.Address = addressInput.Text;
            property.Price = Convert.ToInt32(priceInput.Text);
            context.SaveChanges();
            var window = new MainPropertyWindow();
            this.Close();
            

        }

        private void priceInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var prop = property;
            if (prop != null)
            {
                var propHist = context.Contracts.Where(c => c.PropertyId == prop.Id).FirstOrDefault();
                if (propHist != null)
                {
                    context.Contracts.Remove(propHist);
                    context.SaveChanges();
                }
                context.Remove(prop);
                context.SaveChanges();
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Вознилка ошибка при удалении");
            }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

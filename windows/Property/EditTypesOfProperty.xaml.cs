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
using rentPrac1.Models;

namespace rentPrac1.windows.Property
{
    /// <summary>
    /// Логика взаимодействия для EditTypesOfProperty.xaml
    /// </summary>
    public partial class EditTypesOfProperty : Window
    {
        private readonly AppDbContext context;
        private readonly PropertyType type;

        public EditTypesOfProperty(AppDbContext context, PropertyType type)
        {
            InitializeComponent();
            this.context = context;
            this.type = type;
            nameinput.Text = type.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var propType = type;
            if (propType != null)
            {
                var typeHist = context.Properties.Where(c=> c.TypeId == propType.Id).FirstOrDefault();
                if (typeHist != null)
                {
                    var prophist = context.Contracts.Where(c=> c.PropertyId == propType.Id).FirstOrDefault();
                    if (prophist != null)
                    {
                        context.Contracts.Remove(prophist);
                        context.SaveChanges();
                    }
                    context.Remove(typeHist);
                    context.SaveChanges();

                }

                context.Remove(propType);
                context.SaveChanges();
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            type.Name = nameinput.Text;
            context.SaveChanges();
            this.Close();
        }
    }
}

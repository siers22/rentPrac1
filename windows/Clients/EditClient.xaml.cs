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

namespace rentPrac1.windows.Clients
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        private readonly AppDbContext context;
        private readonly Client client;

        public EditClient(AppDbContext context, Client client)
        {
            InitializeComponent();
            this.context = context;
            this.client = client;
            nameinput.Text = client.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            client.Name = nameinput.Text;
            context.SaveChanges();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var cl = client;
            if (cl != null)
            {
                var clhist = context.Contracts.Where(c => c.ClientId == cl.Id).FirstOrDefault();
                if (clhist != null)
                {
                    context.Contracts.Remove(clhist);
                    context.SaveChanges();
                }
                context.Remove(cl);
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

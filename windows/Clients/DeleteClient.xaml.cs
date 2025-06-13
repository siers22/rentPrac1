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

namespace rentPrac1.windows.Clients
{
    /// <summary>
    /// Логика взаимодействия для DeleteClient.xaml
    /// </summary>
    public partial class DeleteClient : Window
    {
        private readonly AppDbContext contex = new AppDbContext();
        public DeleteClient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var client = contex.Clients.Where(c=> c.Id == Convert.ToInt32(IdInput.Text)).FirstOrDefault();
            if (client != null)
            {
                var contractHistory = contex.Contracts.Where(c => c.ClientId == client.Id).FirstOrDefault();
                if (contractHistory != null)
                {
                    contex.Contracts.Remove(contractHistory);
                    contex.SaveChanges();
                }
                contex.Remove(client);
                contex.SaveChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Такого клиента не существует");
            }

        }
    }
}

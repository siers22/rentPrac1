﻿using System;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace rentPrac1.windows.Clients
{
    /// <summary>
    /// Логика взаимодействия для MainClientsWindow.xaml
    /// </summary>
    public partial class MainClientsWindow : Window
    {
        private readonly AppDbContext context = new AppDbContext();
        public MainClientsWindow()
        {
            InitializeComponent();
            dataList.ItemsSource = context.Clients.ToList();

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new MainWindow();
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window2 = new AddClient();
            window2.Show();
            
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        

        private void dataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = dataList.SelectedItem as Client;
            if (client != null)
            {

                var window4 = new EditClient(context, client);
                window4.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        }

        private void nameinput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var query = context.Clients.AsQueryable();

            
            if (!string.IsNullOrEmpty(nameinput.Text))
            {
                query = query.Where(b => b.Name.Contains(nameinput.Text));
            }

            var result = query.ToList();
            dataList.ItemsSource = result;

        }

       

        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Contracts")
            {
                e.Cancel = true;
            }
        }

       
    }
}

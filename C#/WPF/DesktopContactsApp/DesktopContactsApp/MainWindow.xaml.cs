using DesktopContactsApp.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            this.ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(contact => contact.Name).ToList();

                //var orderedContacts = from c2 in contacts
                //               orderby c2.Name
                //               select c2;
            }

            if (contacts != null)
            {
                listViewContacts.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = contacts.Where(contact => contact.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            
            //var filteredList2 = (from c2 in contacts
            //                     where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
            //                     orderby c2.Email
            //                     select c2.Id).ToList();

            listViewContacts.ItemsSource = filteredList;
        }

        private void listViewContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = listViewContacts.SelectedItem as Contact;
            if (selectedContact != null)
            {
                ContactDetailWindow detail = new ContactDetailWindow(selectedContact);
                detail.ShowDialog();

                ReadDatabase();
            }
        }
    }
}

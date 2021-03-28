using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        static int LevenshteinDistance(string text1, int len1, string text2, int len2)
        {
            if (len1 == 0)
            {
                return len2;
            }

            if (len2 == 0)
            {
                return len1;
            }

            var substitutionCost = 0;
            if (text1[len1 - 1] != text2[len2 - 1])
            {
                substitutionCost = 1;
            }

            var deletion = LevenshteinDistance(text1, len1 - 1, text2, len2) + 1;
            var insertion = LevenshteinDistance(text1, len1, text2, len2 - 1) + 1;
            var substitution = LevenshteinDistance(text1, len1 - 1, text2, len2 - 1) + substitutionCost;
            int[] nmbs = new int[] {deletion,insertion,substitution};

            return nmbs.Min();
        }
        public Main()
        {
            InitializeComponent();
        }

        private void LoadAgents(object sender, RoutedEventArgs e)
        {
            var db = new Entities();
            db.agents.Load();
            Grid.ItemsSource = db.agents.Local.ToBindingList();
        }
        private void LoadClients(object sender, RoutedEventArgs e)
        {
            var db = new Entities();
            db.clients.Load();
            Grid.ItemsSource = db.clients.Local.ToBindingList();
        }
        private void AgentForm(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Show();
        }
        private void ClientForm(object sender, RoutedEventArgs e)
        {
            var win = new ClientWindow();
            win.Show();
        }
       
        private void Searcing(object sender, RoutedEventArgs e)
        {
            var db = new Entities();
            if (RBAgents.IsChecked == true)
            {
                int num = db.agents.Count();
                List<agent> OfSearch = new List<agent>();
                int a = 0;
                db.agents.Load();
                if (MNameSearch.Text == "" && LNameSearch.Text == "")
                {
                    foreach (agent i in db.agents.Local)
                    {
                        int Lev = LevenshteinDistance(i.FirstName, i.FirstName.Length, FNameSearch.Text, FNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
                else if (FNameSearch.Text == "" && LNameSearch.Text == "")
                {
                    foreach (agent i in db.agents.Local)
                    {
                        int Lev = LevenshteinDistance(i.MiddleName, i.MiddleName.Length, MNameSearch.Text, MNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
                else if (FNameSearch.Text == "" && MNameSearch.Text == "")
                {
                    foreach (agent i in db.agents.Local)
                    {
                        int Lev = LevenshteinDistance(i.LastName, i.LastName.Length, LNameSearch.Text, LNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
            }
            else if (RBClients.IsChecked==true)
            {
                int num = db.clients.Count();
                List<client> OfSearch = new List<client>();
                int a = 0;
                db.clients.Load();
                if (MNameSearch.Text == "" && LNameSearch.Text == "")
                {
                    foreach (client i in db.clients.Local)
                    {
                        int Lev = LevenshteinDistance(i.FirstName, i.FirstName.Length, FNameSearch.Text, FNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
                else if (FNameSearch.Text == "" && LNameSearch.Text == "")
                {
                    foreach (client i in db.clients.Local)
                    {
                        int Lev = LevenshteinDistance(i.MiddleName, i.MiddleName.Length, MNameSearch.Text, MNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
                else if (FNameSearch.Text == "" && MNameSearch.Text == "")
                {
                    foreach (client i in db.clients.Local)
                    {
                        int Lev = LevenshteinDistance(i.LastName, i.LastName.Length, LNameSearch.Text, LNameSearch.Text.Length);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                }
                
            }
            
            
        }
    }
}

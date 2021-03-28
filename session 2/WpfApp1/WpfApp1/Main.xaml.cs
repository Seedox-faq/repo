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
        public static int EditDistance(string s, string t)
        {
            int m = s.Length, n = t.Length;
            int[,] ed = new int[m, n];

            for (int i = 0; i < m; ++i)
            {
                ed[i, 0] = i + 1;
            }

            for (int j = 0; j < n; ++j)
            {
                ed[0, j] = j + 1;
            }

            for (int j = 1; j < n; ++j)
            {
                for (int i = 1; i < m; ++i)
                {
                    if (s[i] == t[j])
                    {
                        // Операция не требуется
                        ed[i, j] = ed[i - 1, j - 1];
                    }
                    else
                    {
                        // Минимум между удалением, вставкой и заменой
                        ed[i, j] = Math.Min(ed[i - 1, j] + 1,
                            Math.Min(ed[i, j - 1] + 1, ed[i - 1, j - 1] + 1));
                    }
                }
            }

            return ed[m - 1, n - 1];
        }
        public Main()
        {

            InitializeComponent();
            Ap.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Apatraments ap = new Apatraments();
            ap.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            House1 ap = new House1();
            ap.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Land ap = new Land();
            ap.Show();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Entities db = new Entities();
            if (Ap.IsChecked == true)
            {
                db.apartments.Load();
                Grid.ItemsSource = db.apartments.Local;
            }
            if (H.IsChecked == true)
            {
                db.houses.Load();
                Grid.ItemsSource = db.houses.Local;
            }
            if (L.IsChecked == true)
            {
                db.lands.Load();
                Grid.ItemsSource = db.lands.Local;
            }

        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var db = new Entities();
            if (Ap.IsChecked == true)
            {
                int num = db.apartments.Count();
                List<apartment> OfSearch = new List<apartment>();
                int a = 0;
                db.apartments.Load();
                if (Searched.Text != "")
                {
                    foreach (apartment i in db.apartments.Local)
                    {
                        int Lev = EditDistance(i.Address_Street, Searched.Text);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
            }
            if (H.IsChecked == true)
            {
                int num = db.houses.Count();
                List<house> OfSearch = new List<house>();
                int a = 0;
                db.houses.Load();
                if (Searched.Text != "")
                {
                    foreach (house i in db.houses.Local)
                    {
                        int Lev = EditDistance(i.Address_Street, Searched.Text);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
            }
            if (L.IsChecked == true)
            {
                int num = db.lands.Count();
                List<land> OfSearch = new List<land>();
                int a = 0;
                db.lands.Load();
                if (Searched.Text != "")
                {
                    foreach (land i in db.lands.Local)
                    {
                        int Lev = EditDistance(i.Address_Street, Searched.Text);
                        if (Lev <= 3)
                        {
                            OfSearch.Add(i);
                            a++;
                        }

                    }
                    Grid.ItemsSource = OfSearch;
                }
            }
        }
    }
}
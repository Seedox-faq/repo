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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new Entities();
                db.agents.Load();
                var delete = db.agents.Local.Where(p => p.Id == Convert.ToInt32(DeleteId.Text)).FirstOrDefault();
                db.agents.Remove(delete);
                db.SaveChanges();
            }
            catch
            {

            }
            
        }
        private void Create(object sender, RoutedEventArgs e)
        {
            if (FN.Text != "" || MN.Text != "" || LN.Text != "")
            {
                
                    var db = new Entities();
                    var agentAdd = new agent();
                    agentAdd.FirstName = FN.Text;
                    agentAdd.MiddleName = MN.Text;
                    agentAdd.LastName = LN.Text;
                    agentAdd.DealShare = DS.Text;
                    db.agents.Add(agentAdd);
                    db.SaveChanges();
                
            }
               

        }
        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new Entities();
                var num = Convert.ToInt32(UpdateId.Text);
                var agentUpdate = db.agents.Where(p => p.Id == num).FirstOrDefault();
                if (FNUpdate.Text != "")
                {
                    agentUpdate.FirstName = FNUpdate.Text;
                }
                if (MNUpdate.Text != "")
                {
                    agentUpdate.MiddleName = MNUpdate.Text;
                }
                if (LNUpdate.Text != "")
                {
                    agentUpdate.LastName = LNUpdate.Text;
                }
                if (DSUpdate.Text != "")
                {
                    agentUpdate.DealShare = DSUpdate.Text;
                }
                db.SaveChanges();
            }
            catch
            {

            }
                
            

        }

        
    }
}

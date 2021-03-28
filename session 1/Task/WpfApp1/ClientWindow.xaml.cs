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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new Entities();
                db.clients.Load();
                var delete = db.clients.Local.Where(p => p.Id == Convert.ToInt32(DeleteId.Text)).FirstOrDefault();
                db.clients.Remove(delete);
                db.SaveChanges();
            }
            catch
            {

            }

        }
        private void Create(object sender, RoutedEventArgs e)
        {
            
                if(Ph.Text =="" && Em.Text == "")
                {

                }
                else
                {
                    var db = new Entities();
                    var clientAdd = new client();
                    clientAdd.FirstName = FN.Text;
                    clientAdd.MiddleName = MN.Text;
                    clientAdd.LastName = LN.Text;
                    clientAdd.Phone = Ph.Text;
                    clientAdd.Email = Em.Text;
                    db.clients.Add(clientAdd);
                    db.SaveChanges();
                }


        }
        private void Update(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new Entities();
                var num = Convert.ToInt32(UpdateId.Text);
                var agentUpdate = db.clients.Where(p => p.Id == num).FirstOrDefault();
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
                if (PhUpdate.Text != "")
                {
                    agentUpdate.Phone = PhUpdate.Text;
                }
                if (EmUpdate.Text != "")
                {
                    agentUpdate.Email = EmUpdate.Text;
                }
                db.SaveChanges();
            }
            catch
            {

            }



        }


    }
}


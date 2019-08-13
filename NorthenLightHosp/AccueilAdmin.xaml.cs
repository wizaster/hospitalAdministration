using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NorthenLightHosp
{
    /// <summary>
    /// Logique d'interaction pour AccueilAdmin.xaml
    /// </summary>
    public partial class AccueilAdmin : Window
    {
        employe cetEmploye;
        public ObservableCollection<employe> listeEmployes { get; set;}
        public AccueilAdmin(employe emp)
        {
            InitializeComponent();
            cetEmploye = emp;
            listeEmployes = new ObservableCollection<employe>();
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                cbxRole.DataContext = db.roles.ToList();
            }
            dgEmployes.DataContext = listeEmployes;
        }

        private void cbxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listeEmployes.Count > 0)
            {
                listeEmployes.Clear();
                dgEmployes.Items.Refresh();
            }
            if(cbxRole.SelectedIndex != -1)
            {
                using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                {
                    IEnumerable<employe> liste = db.employes
                        .Where(emp => emp.id_role == (int)cbxRole.SelectedValue)
                        .ToList();
                    foreach (employe ligne in liste)
                    {
                        listeEmployes.Add(ligne);
                    }
                }
            }
            
        }

        private void dgEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgEmployes.CurrentItem != null)
            {
                btnModifier.IsEnabled = true;
                btnSupprimer.IsEnabled = true;
            }
            else
            {
                btnModifier.IsEnabled = false;
                btnSupprimer.IsEnabled = false;
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if(dgEmployes.SelectedItem != null)
            {
                employe employeSel = dgEmployes.SelectedItem as employe;
                var result = MessageBox.Show("Voulez-vous vraiment supprimer cet usager ?", "Attention"
                    , MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if(result == MessageBoxResult.Yes)
                {
                    using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                    {
                        var empASup = db.employes
                            .Where(emp => emp.id == employeSel.id)
                            .FirstOrDefault();
                        if(empASup != null)
                        {
                            db.employes.Remove(empASup);
                            db.SaveChanges();
                        }
                    }
                }
                actualiser();
            }
        }
        public void actualiser()
        {
            cbxRole.SelectedIndex = -1;
            cbxRole.SelectedIndex = 0;
        }
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if(dgEmployes.SelectedItem != null)
            {
                employe sEmp = (employe)dgEmployes.SelectedItem;
                FicheEmploye modifEmp = new FicheEmploye(sEmp);
                modifEmp.ShowDialog();
                actualiser();
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            FicheEmploye nouvelEmp = new FicheEmploye();
            nouvelEmp.ShowDialog();
            actualiser();
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            ListePatients afficherListe = new ListePatients();
            afficherListe.Show();
        }
    }
}

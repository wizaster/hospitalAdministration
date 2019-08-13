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

namespace NorthenLightHosp
{
    /// <summary>
    /// Logique d'interaction pour ListePatients.xaml
    /// </summary>
    public partial class ListePatients : Window
    {
        List<patient> patientTrouver;
        public ListePatients()
        {
            InitializeComponent();
            patientTrouver = new List<patient>();
            affichertout();
            dgPatients.DataContext = patientTrouver;
        }
        public void affichertout()
        {
            using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                var tousPatients = db.patients.ToList();
                foreach (var ligne in tousPatients)
                {
                    patientTrouver.Add(ligne);
                }
            }
        }
        private void txtRecherche_KeyUp(object sender, KeyEventArgs e)
        {
            if (patientTrouver.Count() > 0)
            {
                patientTrouver.Clear();
                dgPatients.Items.Refresh();
            }

            if (txtRecherche.Text.Length > 1)
            {
                string[] aChercher = txtRecherche.Text.Split(' ', ',');
                foreach (string mot in aChercher)
                {
                    using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                    {
                        var trouver = db.patients
                            .Where(pat => pat.nom.ToLower().Contains(mot.ToLower()) ||
                            pat.prenom.ToLower().Contains(mot.ToLower()))
                            .ToList();
                        if (trouver != null)
                            foreach (var patient in trouver)
                            {
                                patient.nom.Trim();
                                patient.prenom.Trim();
                                patientTrouver.Add(patient);
                                dgPatients.Items.Refresh();
                            }
                    }
                }

            }else if(txtRecherche.Text.Length < 1)
            {
                affichertout();
                dgPatients.Items.Refresh();
            }
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            if (dgPatients.SelectedItem != null)
            {
                NouveauPatient miseAjour = new NouveauPatient((patient)dgPatients.SelectedItem);
                miseAjour.ShowDialog();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un patient tout d'abord", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

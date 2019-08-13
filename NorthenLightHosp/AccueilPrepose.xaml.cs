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
    /// Logique d'interaction pour AccueilPrepose.xaml
    /// </summary>
    public partial class AccueilPrepose : Window
    {
        NorthenLightsHopitalEntities db;
        List<patient> patientTrouver;
        employe cetEmploye;
        public AccueilPrepose(employe emp)
        {
            InitializeComponent();
            patientTrouver = new List<patient>();
            dgPatientTrouver.DataContext = patientTrouver;
            cetEmploye = emp;
            
        }

        private void txtRecherche_KeyUp(object sender, KeyEventArgs e)
        {

            if(patientTrouver.Count() > 0)
            {
                patientTrouver.Clear();
                dgPatientTrouver.Items.Refresh();
            }
                
            if (txtRecherche.Text.Length > 1)
            {
                string[] aChercher = txtRecherche.Text.Split(' ', ',');
                foreach(string mot in aChercher)
                {
                    using(db = new NorthenLightsHopitalEntities())
                    {
                        var trouver = db.patients
                            .Where(pat => pat.nom.ToLower().Contains(mot.ToLower()) ||
                            pat.prenom.ToLower().Contains(mot.ToLower()))
                            .ToList();
                        if(trouver != null)
                            foreach(var patient in trouver)
                            {
                                patient.nom.Trim();
                                patient.prenom.Trim();
                                patientTrouver.Add(patient);
                                dgPatientTrouver.Items.Refresh();
                            }
                    }
                    
                }
                
            }
            
        }

        private void dgPatientTrouver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.OriginalSource != null)
            {
                Type type = e.OriginalSource.GetType();
                if(type == typeof(DataGrid) && dgPatientTrouver.SelectedItem != null)
                {
                    patient cePatient = dgPatientTrouver.SelectedItem as patient;
                    using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                    {
                        if ((db.dossier_admission
                            .Where(dos => dos.id_client == cePatient.id)
                            .ToList()
                            .Where(dos => dos.date_conge == null)
                            .ToList()
                            .Count()) < 1 )
                        {
                            btnAdmission.IsEnabled = true;
                        }
                        else
                        {
                            btnAdmission.IsEnabled = false;
                        }
                    }
                    btnMiseAJour.IsEnabled = true;
                }
                else if (dgPatientTrouver.CurrentItem == null)
                {
                    btnAdmission.IsEnabled = false;
                    btnMiseAJour.IsEnabled = false;
                }
                
            }
            
        }

        private void btnMiseAJour_Click(object sender, RoutedEventArgs e)
        {
            if(dgPatientTrouver.SelectedItem != null)
            {
                NouveauPatient miseAjour = new NouveauPatient((patient)dgPatientTrouver.SelectedItem);
                miseAjour.ShowDialog();
            }else
            {
                MessageBox.Show("Veuillez selectionner un patient tout d'abord", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            if (dgPatientTrouver.SelectedItem != null)
            {
                int nbLitsDispo;
                using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                {
                    nbLitsDispo = db.lits
                       .Where(lit => lit.occupe == false)
                       .Count();
                }

                if (nbLitsDispo > 0)
                {
                    nouvelleAdmission nouvelleAdmission = new nouvelleAdmission(dgPatientTrouver.SelectedItem as patient, cetEmploye);
                    nouvelleAdmission.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Aucun lit n'est disponible en ce moment.", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner un patient tout d'abord", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNouveauPatient_Click(object sender, RoutedEventArgs e)
        {
            NouveauPatient AjoutPatient = new NouveauPatient();
            AjoutPatient.ShowDialog();
        }
    }
}

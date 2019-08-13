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
    /// Logique d'interaction pour nouvelleAdmission.xaml
    /// </summary>
    public partial class nouvelleAdmission : Window
    {
        patient cePatient;
        employe cetEmploye;
        public nouvelleAdmission(patient patient, employe emp)
        {
            InitializeComponent();
            cePatient = patient;
            cetEmploye = emp;
            dateAdmission.SelectedDate = DateTime.Now;
            chargementInfoLabel(cePatient);
            populateCombobox();
            
            
        }
        public void chargementInfoLabel(patient pat)
        {
            lblInfoPatient.Content =
                pat.prenom.Trim() + " "
                + pat.nom.Trim() + " | "
                + pat.sexe.Trim() + " | "
                + pat.date_naissance.Date;
        }
        private void btnmodifer_Click(object sender, RoutedEventArgs e)
        {
            NouveauPatient modifPatient = new NouveauPatient(cePatient);
            modifPatient.ShowDialog();

        }
        public void populateCombobox()
        {
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                cbxRaisonAdmission.DataContext = db.raison_admission.ToList();
                cbxDepartement.DataContext = db.departements.ToList();
                cbxMedecin.DataContext = db.employes
                    .Where(emp => emp.id_role == 2)
                    .ToList();
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment quitter ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCommentaire_Click(object sender, RoutedEventArgs e)
        {
            Commentaires nouveauCommentaire = new Commentaires(cePatient, cetEmploye);
            nouveauCommentaire.ShowDialog();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if(cbxDepartement.SelectedItem != null
                && cbxMedecin.SelectedItem != null
                && cbxRaisonAdmission.SelectedItem != null
                && dateAdmission.SelectedDate != null)
            {
                employe medoc = cbxMedecin.SelectedItem as employe;
                raison_admission raison = cbxRaisonAdmission.SelectedItem as raison_admission;
                Dictionary<string, string> admissionData = new Dictionary<string, string>();
                admissionData.Add("id_client", cePatient.id.ToString());
                admissionData.Add("id_medecin", medoc.id.ToString());
                admissionData.Add("date_admission", ((DateTime)dateAdmission.SelectedDate).ToString());
                admissionData.Add("raison_admission", raison.designation);
                Accomodations choixAccomodations = new Accomodations(cePatient, cbxDepartement.SelectedItem as departement, admissionData);
                choixAccomodations.ShowDialog();
                this.Close();
                
            }else
            {
                MessageBox.Show("Veuillez remplir toutes les options", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}

using System;
using System.Collections;
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
    /// Logique d'interaction pour AccueilMedecin.xaml
    /// </summary>
    public partial class AccueilMedecin : Window
    {
        NorthenLightsHopitalEntities db;
        public ObservableCollection<View_dossier_nom_prenom> patientInfo { get; set; }
        public ObservableCollection<View_nom_medecin> patientHistorique { get; set; }
        
        
        employe employe;
        public AccueilMedecin(employe emp)
        {
            InitializeComponent();
            employe = emp;
            patientInfo = new ObservableCollection<View_dossier_nom_prenom>();
            patientHistorique = new ObservableCollection<View_nom_medecin>();
            dgHistorique.DataContext = patientHistorique;
            dgPatients.DataContext = patientInfo;
            lblGreeting.Content = "Bonjour, " + emp.prenom.TrimEnd() + " " + emp.nom.Trim();


            using (db = new NorthenLightsHopitalEntities())
            {
                cboPatient.DataContext = db.View_dossier_nom_prenom
                    .Where(pat => pat.id_medecin == employe.id)
                    .GroupBy(pat => pat.id_client)
                    .Select(pati => pati.FirstOrDefault())
                .ToList();               
            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patientInfo.Clear();
            patientHistorique.Clear();
            int idClient = Convert.ToInt16(cboPatient.SelectedValue);
            using (db = new NorthenLightsHopitalEntities())
            {
                View_dossier_nom_prenom toAdd =
                    db.View_dossier_nom_prenom
                    .Where(pat => pat.id_client == idClient)
                    .ToList()
                    .Where(pat => pat.date_conge == null)
                    .FirstOrDefault();
                if (toAdd != null)
                    patientInfo.Add(toAdd);
                IEnumerable<View_nom_medecin> afficherHistorique =
                    db.View_nom_medecin
                    .Where(pat => pat.id_client == idClient)
                    .ToList()
                    .Where(pat => pat.date_conge != null)
                    .ToList();
                foreach (var ligne in afficherHistorique)
                {
                    patientHistorique.Add(ligne);
                }
            }
        }

        private void btnConge_Click(object sender, RoutedEventArgs e)
        {
            int patient = 0;
            patient = (int)cboPatient.SelectedValue;
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                var dossier = db.dossier_admission
                    .Where(dos => dos.id_client == (int)cboPatient.SelectedValue
                    && dos.date_conge == null)
                    .FirstOrDefault();
                if (dossier != null)
                {
                    DonnerConge choixDate = new DonnerConge(dossier.id);
                    choixDate.Show();
                }
            }
            
            
            
        }
    }
}

   


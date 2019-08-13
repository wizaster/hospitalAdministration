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
    /// Logique d'interaction pour Accomodations.xaml
    /// </summary>
    public partial class Accomodations : Window
    {
        patient cePatient;
        departement ceDep;
        bool freeUpgrade = false;
        Dictionary<string, string> admissionData;
        public ObservableCollection<View_lits_informations> listeLitsUp;
        IEnumerable<View_lits_informations> listeLits;
        View_lits_informations litChoisi;
        int age;
        public Accomodations(patient patient, departement dep, Dictionary<string, string> valeurs)
        {
            InitializeComponent();
            ceDep = dep;
            cePatient = patient;
            admissionData = valeurs;
            listeLitsUp = new ObservableCollection<View_lits_informations>();
            age = calculerAge();
            rbStandard.IsChecked = true;
            dgLits.DataContext = listeLitsUp;
           
        }
        public int calculerAge()
        {
            int age = (DateTime.Today).Year - cePatient.date_naissance.Year;
            if(cePatient.date_naissance.Date > DateTime.Today.AddYears(-age))
            {
                age--;
                return age;
            }
            return age;     
        }
        public void litPreselectionner(ObservableCollection<View_lits_informations> liste)
        {
            
            foreach (View_lits_informations lit in liste)
            {
                if (age <= 16)
                {
                    if (ceDep.designation != "chirurgie")
                    {
                        if(lit.id_departement == 2)
                        {
                            litChoisi = lit;
                            dgLits.SelectedItem = litChoisi;
                            dgLits.UpdateLayout();
                            dgLits.ScrollIntoView(litChoisi);
                            return;
                        }
                    }
                }
                if (lit.id_departement == ceDep.id)
                {
                    litChoisi = lit;
                    dgLits.SelectedItem = litChoisi;
                    dgLits.UpdateLayout();
                    dgLits.ScrollIntoView(litChoisi);
                    return;
                }
            }
            MessageBox.Show("Aucune chambres du type voulu n'est disponible en ce moment dans ce departement", "Desole"
                    , MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        public void populateListBox(string type)
        {
            listeLitsUp.Clear();
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                switch (type)
                {
                    case "standard":
                        listeLits = db.View_lits_informations
                        .Where(acc => acc.id_accomodation == 1
                        && acc.occupe == false)
                        .ToList();
                        if (dgLits.Items == null)
                        {
                            freeUpgrade = true;
                            rbSemiPrive.IsChecked = true;
                        }
                        foreach (var lit in listeLits)
                        {
                            listeLitsUp.Add(lit);
                        }
                        litPreselectionner(listeLitsUp);
                        break;
                    case "semi-prive":
                        listeLits = db.View_lits_informations
                        .Where(acc => acc.id_accomodation == 2
                        && acc.occupe == false)
                        .ToList();
                        if (dgLits.Items.Count < 1 && freeUpgrade == true)
                        {
                            rbPrive.IsChecked = true;
                        }
                        foreach(var lit in listeLits)
                        {
                            listeLitsUp.Add(lit);
                        }
                        litPreselectionner(listeLitsUp);
                        break;
                    case "prive":
                        listeLits = db.View_lits_informations
                        .Where(acc => acc.id_accomodation == 3
                        && acc.occupe == false)
                        .ToList();
                        foreach (var lit in listeLits)
                        {
                            listeLitsUp.Add(lit);
                        }
                        litPreselectionner(listeLitsUp);
                        break;
                }
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

        private void rbStandard_Checked(object sender, RoutedEventArgs e)
        {
            populateListBox("standard");
        }

        private void rbSemiPrive_Checked(object sender, RoutedEventArgs e)
        {
            populateListBox("semi-prive");
        }

        private void rbPrive_Checked(object sender, RoutedEventArgs e)
        {
            populateListBox("prive");
        }
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                if (dgLits.SelectedItem != null)
                {

                    accomodation_sejour nouvelAccTelevision = null;
                    accomodation_sejour nouvelAccTelephone = null;
                    try
                    {
                        dossier_admission nouvelAdmission = new dossier_admission
                        {
                            id_client = int.Parse(admissionData["id_client"]),
                            id_medecin = int.Parse(admissionData["id_medecin"]),
                            date_admission = Convert.ToDateTime(admissionData["date_admission"]),
                            raison_admission = admissionData["raison_admission"],
                            id_lit = litChoisi.id
                        };
                        db.dossier_admission.Add(nouvelAdmission);
                        db.SaveChanges();
                        int idDossier = nouvelAdmission.id;

                        if (ckbxTelephone.IsChecked == true)
                        {
                            nouvelAccTelephone = new accomodation_sejour
                            {
                                id_dossier_admission = idDossier,
                                id_accomodation = 5,
                                date_debut = nouvelAdmission.date_admission,
                                upgrade_sans_frais = false
                            };
                        }
                        if (ckbxTelevision.IsChecked == true)
                        {
                            nouvelAccTelevision = new accomodation_sejour
                            {
                                id_dossier_admission = idDossier,
                                id_accomodation = 4,
                                date_debut = nouvelAdmission.date_admission,
                                upgrade_sans_frais = false
                            };
                        }
                        accomodation_sejour nouvelAccChambre = new accomodation_sejour
                        {
                            id_dossier_admission = idDossier,
                            id_accomodation = litChoisi.id_accomodation,
                            date_debut = nouvelAdmission.date_admission,
                            upgrade_sans_frais = freeUpgrade
                        };
                        if (ckbxTelevision.IsChecked == true)
                        {
                            db.accomodation_sejour.Add(nouvelAccTelephone);
                        }


                        if (ckbxTelephone.IsChecked == true)
                        {
                            db.accomodation_sejour.Add(nouvelAccTelevision);
                        }
                        db.accomodation_sejour.Add(nouvelAccChambre);
                        db.lits
                            .Where(li => li.id == litChoisi.id)
                            .ToList()
                            .FirstOrDefault().occupe = true;
                        db.SaveChanges();
                        MessageBox.Show("Le patient a ete admis avec succes", "Succes"
                    , MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite : \n" +
                    ex.Message.ToString(), "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Close();
                    }
                }

            }
            
        }

       
    }
}

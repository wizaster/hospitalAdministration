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
    /// Logique d'interaction pour NouveauPatient.xaml
    /// </summary>
    public partial class NouveauPatient : Window
    {
        patient cePatient = null;
        public NouveauPatient()
        {
            InitializeComponent();
        }
        public NouveauPatient(patient patient)
        {
            InitializeComponent();
            cePatient = patient;
            initialiserChamps(cePatient);
        }
        public void initialiserChamps(patient patient)
        {
            txtNom.Text = patient.nom;
            txtPrenom.Text = patient.prenom;
            txtParent.Text = patient.proche_parent;
            dateNais.SelectedDate = patient.date_naissance;
            if(patient.sexe == "F")
            {
                rbFemme.IsChecked = true;
            }
            else if(patient.sexe == "H")
            {
                rbHomme.IsChecked = true;
            }
            assurance patAss = verifierAssurance(patient);
            if (patAss != null)
            {
                txtAssNom.Text = patAss.nom_societe_assurance;
                txtAssNoPol.Text = patAss.no_police.ToString();
                ckbxAss.IsChecked = true;
            }

        }
        public assurance verifierAssurance(patient patient)
        {
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                return db.assurances
                    .Where(pat => pat.id_client == patient.id)
                    .FirstOrDefault();
            }
        }
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (champsRempli())
            {
                try
                {
                    using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                    {
                        if(cePatient == null)
                        {
                            patient nouveauPatient = new patient
                            {
                                nom = txtNom.Text,
                                prenom = txtPrenom.Text,
                                date_naissance = (DateTime)dateNais.SelectedDate,
                                proche_parent = txtParent.Text
                            };
                            db.patients.Add(nouveauPatient);
                            db.SaveChanges();
                            int idPatient = nouveauPatient.id;
                            if (ckbxAss.IsChecked == true)
                            {
                                assurance nouvellePolice = new assurance
                                {
                                    no_police = int.Parse(txtAssNoPol.Text),
                                    nom_societe_assurance = txtAssNom.Text,
                                    id_client = idPatient
                                };
                                db.assurances.Add(nouvellePolice);
                                db.SaveChanges();
                            }
                        }else
                        {
                            patient aModif = cePatient;
                            aModif.date_naissance = (DateTime)dateNais.SelectedDate;
                            aModif.nom = txtNom.Text;
                            aModif.prenom = txtPrenom.Text;
                            aModif.proche_parent = txtParent.Text;
                            if(ckbxAss.IsChecked == true)
                            {
                                assurance nouvellePolice = new assurance
                                {
                                    no_police = int.Parse(txtAssNoPol.Text),
                                    nom_societe_assurance = txtAssNom.Text,
                                    id_client = aModif.id
                                };
                                db.assurances.Add(nouvellePolice);
                            }
                            db.Entry(aModif).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                        }
                        
                    }
                    succes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : \n" +
                        ex.Message.ToString(), "Attention"
                        , MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

            }else
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "ATTENTION"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void succes()
        {
            MessageBox.Show("Le patient a ete ajouté avec succès", "Succes"
                , MessageBoxButton.OK, MessageBoxImage.Exclamation);
            this.Close();
        }
        public bool champsRempli()
        {
            if(ckbxAss.IsChecked == true)
            {
                return !String.IsNullOrEmpty(txtNom.Text)
                && !String.IsNullOrEmpty(txtPrenom.Text)
                && (rbFemme.IsChecked == true || rbHomme.IsChecked == true)
                && dateNais.SelectedDate != null
                && !String.IsNullOrEmpty(txtAssNom.Text)
                && (!String.IsNullOrEmpty(txtAssNoPol.Text) && txtAssNoPol.Text.All(Char.IsDigit));
            }else
            {
                return !String.IsNullOrEmpty(txtNom.Text)
                && !String.IsNullOrEmpty(txtPrenom.Text)
                && (rbFemme.IsChecked == true || rbHomme.IsChecked == true)
                && dateNais.SelectedDate != null;
            }             
            
        }

        private void ckbxAss_Checked(object sender, RoutedEventArgs e)
        {
            
                groupBoxAss.IsEnabled = true;
        }

        private void ckbxAss_Unchecked(object sender, RoutedEventArgs e)
        {
            groupBoxAss.IsEnabled = false;
        }
    }
}

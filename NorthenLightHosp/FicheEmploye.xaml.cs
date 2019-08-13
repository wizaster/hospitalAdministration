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
    /// Logique d'interaction pour FicheEmploye.xaml
    /// </summary>
    public partial class FicheEmploye : Window
    {
        employe cetEmploye = null;
        NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities();
        public FicheEmploye()
        {
            InitializeComponent();
            cbxRole.DataContext = db.roles.ToList();
        }
        public FicheEmploye(employe emp)
        {
            InitializeComponent();
            cetEmploye = emp;
            cbxRole.DataContext = db.roles.ToList();
            
            txtNom.Text = emp.nom;
            txtPrenom.Text = emp.prenom;
            txtUsername.Text = emp.nom_utilisateur;
            txtPasswd.Password = emp.mot_passe;
            cbxRole.SelectedIndex = emp.id_role - 1;
        }
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (champsRemplis())
            {
                
                    try
                    {
                        if (cetEmploye != null)
                        {
                            //employe empAModif = db.employes
                            //    .Where(emp => emp.id == cetEmploye.id)
                            //    .FirstOrDefault();
                            employe empAModif = cetEmploye;
                            empAModif.nom = txtNom.Text;
                            empAModif.prenom = txtPrenom.Text;
                            empAModif.nom_utilisateur = txtUsername.Text;
                            empAModif.mot_passe = txtPasswd.Password;
                            empAModif.id_role = (int)cbxRole.SelectedValue;
                            db.Entry(empAModif).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            MessageBox.Show("Modification reussi!", "succes"
                                , MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            this.Close();
                        }
                        else
                        {
                            employe nouvelEmploye = new employe
                            {
                                nom = txtNom.Text,
                                prenom = txtPrenom.Text,
                                nom_utilisateur = txtUsername.Text,
                                mot_passe = txtPasswd.Password,
                                id_role = (int)cbxRole.SelectedValue
                            };
                            db.employes.Add(nouvelEmploye);
                            db.SaveChanges();
                            MessageBox.Show("Ajout reussi!", "succes"
                                , MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            this.Close();
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Une erreur s'est produite : \n" +
                    ex.Message.ToString(), "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Close();
                    }
                   
                
               
            }
        }
        public bool champsRemplis()
        {
            return !String.IsNullOrEmpty(txtNom.Text)
                && !String.IsNullOrEmpty(txtPrenom.Text)
                && !String.IsNullOrEmpty(txtUsername.Text)
                && !String.IsNullOrEmpty(txtPasswd.Password)
                && cbxRole.SelectedIndex != -1;
        }
    }
}

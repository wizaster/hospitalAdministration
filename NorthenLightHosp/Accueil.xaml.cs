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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Window
    {
        NorthenLightsHopitalEntities db;
        public Accueil()
        {
            InitializeComponent();
            db = new NorthenLightsHopitalEntities();
        }

        private void btnEntrer_Click(object sender, RoutedEventArgs e)
        {
            var emp = db.employes.FirstOrDefault(empl => empl.nom_utilisateur == txtUsername.Text);
            if(emp != null)
            {
                if (emp.mot_passe.Trim() == txtPasswd.Password)
                {
                    int role = emp.id_role;
                    switch (role)
                    {
                        case 1:
                            this.Hide();
                            AccueilAdmin sessionAdmin = new AccueilAdmin(emp);
                            sessionAdmin.ShowDialog();
                            this.Show();
                            break;
                        case 2:
                            this.Hide();
                            AccueilMedecin sessionMed = new AccueilMedecin(emp);
                            sessionMed.ShowDialog();
                            this.Show();
                            break;
                        case 3:
                            this.Hide();
                            AccueilPrepose sessionPrep = new AccueilPrepose(emp);
                            sessionPrep.ShowDialog();
                            this.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Le nom utilisateur ou le mot de passe sont erroné", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPasswd.Clear();
                }
            }
            else
            {
                MessageBox.Show("Le nom utilisateur ou le mot de passe sont erroné", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPasswd.Clear();
            }


        }
        public employe valider()
        {
            var emp = db.employes.FirstOrDefault(empl => empl.nom_utilisateur == txtUsername.Text);
            if(emp.mot_passe != txtPasswd.Password.ToString())
                return null;
            return emp;
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
            {
                this.Close();
            }

        }
    }
}

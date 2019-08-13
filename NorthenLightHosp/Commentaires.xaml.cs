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
    /// Logique d'interaction pour Commentaires.xaml
    /// </summary>
    public partial class Commentaires : Window
    {
        patient cePatient;
        employe cetEmploye;
        public Commentaires(patient patient, employe emp)
        {
            InitializeComponent();
            cePatient = patient;
            cetEmploye = emp;
            lblNom.Content = cePatient.prenom + " " + cePatient.nom;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                try
                {
                    commentaire_patient nouveauCommentaire = new commentaire_patient
                    {
                        id_client = cePatient.id,
                        id_medecin = cetEmploye.id,
                        commentaire = txtCommentaire.Text,
                        date = DateTime.Now
                    };
                    db.commentaire_patient.Add(nouveauCommentaire);
                    db.SaveChanges();
                    this.Close();
                }catch(Exception ex)
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

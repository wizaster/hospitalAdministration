using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour DonnerConge.xaml
    /// </summary>
    public partial class DonnerConge : Window
    {
        int id_admission;
        dossier_admission dossier;
        bool estAssurer = false;
        public DonnerConge(int id)
        {
            InitializeComponent();
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                dossier = db.dossier_admission
                    .Where(dos => dos.id == id)
                    .FirstOrDefault();
            }
            id_admission = id;
            estAssurer = verifierAssurance();
        }
        public bool verifierAssurance()
        {
            using(NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
            {
                
                return (db.assurances
                     .Where(ass => ass.id_client == dossier.id_client)
                     .Count()) > 0;     
            }
        }
        private void btnAppliquer_Click(object sender, RoutedEventArgs e)
        {
            
            
            DateTime choix = (DateTime)conge.SelectedDate;
            if (choix != null)
            {
                using (NorthenLightsHopitalEntities db = new NorthenLightsHopitalEntities())
                {
                    db.dossier_admission
                        .Where(dos => dos.id == id_admission)
                        .ToList()
                        .FirstOrDefault().date_conge = choix;
                    db.SaveChanges();
                    db.lits
                        .Where(li => li.id == dossier.id_lit)
                        .ToList()
                        .ForEach(li => li.occupe = false);
                    db.accomodation_sejour
                        .Where(acc => acc.id_dossier_admission == id_admission)
                        .ToList()
                        .ForEach(acc => acc.date_fin = choix);
                    db.SaveChanges();

                    IEnumerable<View_accomodation_information> aFacturer = db.View_accomodation_information
                        .Where(acc => acc.id_dossier_admission == id_admission)
                        .ToList();
                    messageSucces();
                    nouvelleFacture(aFacturer);
                }
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner une date.", "Attention"
                    , MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
        public void messageSucces()
        {
            MessageBox.Show("Congé effectif!", "Succes", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            this.Close();
        }
        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void nouvelleFacture(IEnumerable<View_accomodation_information> aFacturer)
        {
            string nomFichier = "Facture client No " + id_admission + ".txt";
            string destPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomFichier);
            string facture = "";
            decimal totalTotal = 0;
            foreach(View_accomodation_information ligneFacture in aFacturer)
            {
                decimal total = (decimal)((DateTime)ligneFacture.date_fin - (DateTime)ligneFacture.date_debut).TotalDays * ligneFacture.tarif_quotidien;
                facture += "\n " + ligneFacture.designation + " au tarif journalier de " + ligneFacture.tarif_quotidien
                    + "\n Date de debut : " + ligneFacture.date_debut
                    + "\n Date de fin : " + ligneFacture.date_fin
                    + "\n Total : " + total;
                if (estAssurer)
                {
                    facture += "\n Couvert par vos assurance"
                        + "\n total = 0";
                    total = 0;
                }else if ((bool)ligneFacture.upgrade_sans_frais)
                {
                    facture += "\n L'upgrade est a nos frais"
                        + "\n total = 0";
                    total = 0;
                }
                facture += "\n------------------------------------------";
                totalTotal += total;

            }
            facture += "\n Montant total : " + totalTotal;
            System.IO.File.WriteAllText(destPath, facture);
        }

        private void conge_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAppliquer.IsEnabled = true;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthenLightHosp
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_accomodation_information
    {
        public decimal tarif_quotidien { get; set; }
        public int id { get; set; }
        public int id_dossier_admission { get; set; }
        public int id_accomodation { get; set; }
        public System.DateTime date_debut { get; set; }
        public Nullable<System.DateTime> date_fin { get; set; }
        public Nullable<bool> upgrade_sans_frais { get; set; }
        public string designation { get; set; }
    }
}

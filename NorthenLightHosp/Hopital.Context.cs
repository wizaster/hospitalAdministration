﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NorthenLightsHopitalEntities : DbContext
    {
        public NorthenLightsHopitalEntities()
            : base("name=NorthenLightsHopitalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<accomodation> accomodations { get; set; }
        public virtual DbSet<accomodation_sejour> accomodation_sejour { get; set; }
        public virtual DbSet<assurance> assurances { get; set; }
        public virtual DbSet<commentaire_patient> commentaire_patient { get; set; }
        public virtual DbSet<departement> departements { get; set; }
        public virtual DbSet<dossier_admission> dossier_admission { get; set; }
        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<lit> lits { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<raison_admission> raison_admission { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<View_accomodation_information> View_accomodation_information { get; set; }
        public virtual DbSet<View_dossier_nom_prenom> View_dossier_nom_prenom { get; set; }
        public virtual DbSet<View_lits_informations> View_lits_informations { get; set; }
        public virtual DbSet<View_nom_medecin> View_nom_medecin { get; set; }
    }
}
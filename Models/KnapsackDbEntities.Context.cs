﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnapSack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KnapsackDBEntities : DbContext
    {
        public KnapsackDBEntities()
            : base("name=KnapsackDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arme> Armes { get; set; }
        public virtual DbSet<Armure> Armures { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Joueur> Joueurs { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Repons> Reponses { get; set; }
        public virtual DbSet<Sac> Sacs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TypesArme> TypesArmes { get; set; }
        public virtual DbSet<TypesItem> TypesItems { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
    }
}

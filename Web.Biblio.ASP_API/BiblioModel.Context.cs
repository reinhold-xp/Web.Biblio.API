﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Biblio.ASP_API
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class biblioEntities : DbContext
    {
        public biblioEntities()
            : base("name=biblioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Livres> Livres { get; set; }
        public virtual DbSet<Auteurs> Auteurs { get; set; }

        public System.Data.Entity.DbSet<Web.Biblio.ASP_API.DtoAuteur> DTO_Auteur { get; set; }
    }
}

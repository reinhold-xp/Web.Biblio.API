using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Biblio.ASP_API
{
    public class DtoLivre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int Pages { get; set; }
        public string Image { get; set; }
        public string Resume { get; set; }
        public int IdAuteur { get; set; }
        public string AuteurNom { get; set; }
    }
}
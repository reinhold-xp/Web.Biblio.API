using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Biblio.ASP_API
{
    public class DtoAuteur
    {
        public int Id { get; internal set; }
        public DateTime? DateNaissance { get; internal set; }
        public string Nom { get; internal set; }
        public string Nationalite { get; internal set; }
    }
}
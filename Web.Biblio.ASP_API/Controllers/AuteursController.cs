using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web.Biblio.ASP_API;

namespace Web.Biblio.ASP_API.Controllers
{
    public class AuteursController : ApiController
    {
        private biblioEntities db = new biblioEntities();

        // GET: api/Auteurs
        public IQueryable<DtoAuteur> GetAuteurs()
        {
            return db.Auteurs.Select(a => new DtoAuteur
            {
                Id = a.id,
                Nom = a.nom,
                DateNaissance = a.date_naissance,
                Nationalite = a.nationalite
            });
        }

        // GET: api/Auteurs/5
        [ResponseType(typeof(DtoAuteur))]
        public IHttpActionResult GetAuteursById(int id)
        {
            var auteur = db.Auteurs
                .Where(a => a.id == id)
                .Select(a => new DtoAuteur
                {
                    Id = a.id,
                    Nom = a.nom,
                    DateNaissance = a.date_naissance,
                    Nationalite = a.nationalite
                })
                .FirstOrDefault();

            if (auteur == null)
                return NotFound();

            return Ok(auteur);
        }

        // POST désactivé
        public IHttpActionResult PostAuteurs(Auteurs a)
        {
            return Content(HttpStatusCode.MethodNotAllowed, "Création désactivée temporairement.");
        }

        // PUT désactivé
        public IHttpActionResult PutAuteurs(int id, Auteurs a)
        {
            return Content(HttpStatusCode.MethodNotAllowed, "Modification désactivée temporairement.");
        }

        // DELETE désactivé
        public IHttpActionResult DeleteAuteurs(int id)
        {
            return Content(HttpStatusCode.MethodNotAllowed, "Suppression désactivée temporairement.");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool AuteursExists(int id)
        {
            return db.Auteurs.Any(a => a.id == id);
        }
    }

}
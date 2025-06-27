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
    public class LivresController : ApiController
    {
        private biblioEntities db = new biblioEntities();

        // GET: api/Livres
        public IQueryable<DtoLivre> GetLivres()
        {
            return from l in db.Livres
                   join a in db.Auteurs on l.id_auteur equals a.id
                   select new DtoLivre
                   {
                       Id = l.id,
                       Titre = l.titre,
                       Pages = l.pages,
                       Image = l.image,
                       Resume = l.resume,
                       IdAuteur = l.id_auteur,
                       AuteurNom = a.nom
                   };
        }

        // GET: api/Livres/5
        [ResponseType(typeof(DtoLivre))]
        public IHttpActionResult GetLivresById(int id)
        {
            var livre = (from l in db.Livres
                         join a in db.Auteurs on l.id_auteur equals a.id
                         where l.id == id
                         select new DtoLivre
                         {
                             Id = l.id,
                             Titre = l.titre,
                             Pages = l.pages,
                             Image = l.image,
                             Resume = l.resume,
                             IdAuteur = l.id_auteur,
                             AuteurNom = a.nom
                         }).FirstOrDefault();

            if (livre == null)
                return NotFound();

            return Ok(livre);
        }

        // PUT: api/Livres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivres(int id, Livres livres)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //if (id != livres.id)
            //    return BadRequest();

            //db.Entry(livres).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!LivresExists(id))
            //        return NotFound();
            //    else
            //        throw;
            //}

            //return StatusCode(HttpStatusCode.NoContent);
            return Content(HttpStatusCode.MethodNotAllowed, "Modification désactivée temporairement");
        }
        
        // POST: api/Livres
        [ResponseType(typeof(DtoLivre))]
        public IHttpActionResult PostLivres(Livres livres)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //db.Livres.Add(livres);
            //db.SaveChanges();

            //var auteur = db.Auteurs.FirstOrDefault(a => a.id == livres.id_auteur);

            //var dto = new LivreDTO
            //{
            //    Id = livres.id,
            //    Titre = livres.titre,
            //    Pages = livres.pages,
            //    Image = livres.image,
            //    Resume = livres.resume,
            //    IdAuteur = livres.id_auteur,
            //    AuteurNom = auteur?.nom
            //};

            //return CreatedAtRoute("DefaultApi", new { id = dto.Id }, dto);
            return Content(HttpStatusCode.MethodNotAllowed, "Création désactivée temporairement");
        }

        // DELETE: api/Livres/5
        [ResponseType(typeof(DtoLivre))]
        public IHttpActionResult DeleteLivres(int id)
        {
            //var livre = db.Livres.Find(id);
            //if (livre == null)
            //    return NotFound();

            //var auteur = db.Auteurs.FirstOrDefault(a => a.id == livre.id_auteur);

            //var dto = new LivreDTO
            //{
            //    Id = livre.id,
            //    Titre = livre.titre,
            //    Pages = livre.pages,
            //    Image = livre.image,
            //    Resume = livre.resume,
            //    IdAuteur = livre.id_auteur,
            //    AuteurNom = auteur?.nom
            //};

            //db.Livres.Remove(livre);
            //db.SaveChanges();

            //return Ok(dto);
            return Content(HttpStatusCode.MethodNotAllowed, "Suppression désactivée temporairement");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool LivresExists(int id)
        {
            return db.Livres.Any(e => e.id == id);
        }
    }

}
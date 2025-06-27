
<h1>API RESTful & portail API</h1>
<p align="center">
  <img src="https://raw.githubusercontent.com/reinhold-xp/Web.Biblio.API/master/Web.Biblio.ASP_API/Images/git.png" alt="Aperçu du projet" width="900"/>
</p>
<p>
  <strong>ASP.NET Web API + Entity Framework (Database First) + DTOs</strong>
</p>

## Endpoints 

### Livres (`/api/Livres`)
- `GET /api/Livres` 
- `GET /api/Livres/{id}` 
- `POST / PUT / DELETE` 

### Auteurs (`/api/Auteurs`)
- `GET /api/Auteurs` 
- `GET /api/Auteurs/{id}` 
- `POST / PUT / DELETE` 

## Architecture

### Entity Framework `.edmx`
- Modèle généré depuis la base (`biblioEntities`)
- Navigation entre `Livres` et `Auteurs` **supprimée**
- Jointures faites manuellement en LINQ (pas de propriétés de navigation)

### DTOs
- `DtoLivre.cs` : structure publique des livres
- `DtoAuteur.cs` : structure publique des auteurs
- Avantages :
  - JSON propre, stable
  - Pas de cycles de sérialisation
  - Couche d’abstraction entre EF et l’API

## 💡 Étapes de mise en place

1. Création du projet Web API (.NET Framework)
2. Import du modèle `.edmx` depuis la base de données
3. Suppression manuelle des propriétés de navigation indésirables
4. Création des classes `DtoLivre` et `DtoAuteur`
5. Mise en place des contrôleurs :
   - Projection LINQ des entités EF vers les DTOs
   - Méthodes `POST`, `PUT`, `DELETE` désactivées temporairement (`405`)
6. Vérification via **Swagger** (WebApiConfig + NuGet `Swashbuckle`)

## Extrait de code 

```csharp
// Projection manuelle d’un livre avec son auteur (jointure explicite)
from l in db.Livres
join a in db.Auteurs on l.id_auteur equals a.id
select new DtoLivre {
    Id = l.id,
    Titre = l.titre,
    AuteurNom = a.nom,
    ...
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.Biblio.ASP_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Supprime le formatter XML pour que l'API renvoie uniquement des réponses en JSON,
            // on évite les erreurs de sérialisation XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Récupère le formatter JSON par défaut…
            var json = config.Formatters.JsonFormatter;

            // Configure pour qu'il ignore les références circulaires
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

        }
    }
}

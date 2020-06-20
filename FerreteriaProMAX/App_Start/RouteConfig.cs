using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FerreteriaProMAX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                           name: "Default",
                           url: "{controller}/{action}/{id}",
                           defaults: new { controller = "USUARIO_LOGIN", action = "Login", id = UrlParameter.Optional }
                       );
            routes.MapRoute(
                name: "Cargos",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cargo", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CargosAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cargo", action = "Crete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Categoria",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Categoria", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoriaAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Categorias", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Empleado",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Empleado", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EmpleadoAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Empleado", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Facturas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Factura", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FacturasAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Factura", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Marcas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Marca", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MarcasAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Marca", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Personas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persona", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PersonasAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persona", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Proveedores",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Proveedores", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProveedoresAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Proveedores", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Producto",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Producto", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProductoAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Productoes", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Roles",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Roles", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RolesAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Roles", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TipoPago",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoPagoes", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TipoPagoAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoPagoes", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Usuario_Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "USUARIO_LOGIN", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Ventas",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ventas", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "VentasaAdd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ventas", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Inicio",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

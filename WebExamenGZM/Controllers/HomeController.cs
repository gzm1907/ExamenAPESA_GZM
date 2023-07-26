using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebExamenGZM.Controllers
{
    public class HomeController : Controller
    {
        // Vista principal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarDatos(string nombreCompleto, DateTime? fechaNacimiento, string correo)
        {
            if(String.IsNullOrEmpty(nombreCompleto) || String.IsNullOrEmpty(correo) || !fechaNacimiento.HasValue)
            {
                TempData["resultado"] = "No se aceptan cajas vacías";
            }
            //Flujo del programa una vez que se valido que no se reciban datos vacíos
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                //Personalicen la ruta de acuerdo al lugar dónde quieren que aparezca el archivo
                StreamWriter sw = new StreamWriter("C:\\Users\\kidji\\Desktop\\APESA\\GZM.txt");
                //Cada una de las líneas compone uno de los datos a recibir
                sw.WriteLine("Lista de datos solicitados:");
                sw.WriteLine("1. "+nombreCompleto);
                sw.WriteLine("2. "+fechaNacimiento);
                sw.WriteLine("3. "+correo);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            //Mensaje que aparece en la vista principal
            TempData["resultado"] = "Éxito, datos agregados";
            return RedirectToAction("Index");
        }
    }
}
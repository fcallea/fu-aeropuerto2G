using AeropuertoG2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AeropuertoG2.Controllers
{
    public class AsignarVueloTripulacionController : Controller
    {
        // GET: AsignacionTripulacion
        public ActionResult ListarTripulacion()
        {

            var url = "https://localhost:44365/api/Tripulacion/ListarTripulacion";
            //var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 300000;
            var json = ""; //JsonConvert.SerializeObject(datos);

            /*ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();*/

            // Invocación del servicio
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var Resultado = sr.ReadToEnd();

            var m = JsonConvert.DeserializeObject<List<AsignarVueloTripulacionModel>>(Resultado);
            Session["listaTripulacionAsig"] = m;
            //dataGridView1.DataSource = Resultado;
            //return Task.CompletedTask;
            return View();
        }     
    }
}
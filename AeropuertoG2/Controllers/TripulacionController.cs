using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AeropuertoG2.Models;
using Newtonsoft.Json;

namespace AeropuertoG2.Controllers
{
    public class TripulacionController : Controller
    {
        // GET: Tripulacion
        public ActionResult Tripulacion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tripulacion(Models.TripulacionViewModel datos, string submitButton)
        {
            switch (submitButton)
            {
                case "CrearTripulacion":
                    if (datos.tripulacionNombre != null)
                    {
                        var url = "https://localhost:7109/api/Tripulacion";
                        //var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
                        var request = (HttpWebRequest)WebRequest.Create(url);
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        request.Timeout = 300000;
                        var json = JsonConvert.SerializeObject(datos);
                        //request.ContentLength.b = json.Length;

                        ASCIIEncoding encoding = new ASCIIEncoding();
                        Byte[] bytes = encoding.GetBytes(json);

                        Stream newStream = request.GetRequestStream();
                        newStream.Write(bytes, 0, bytes.Length);
                        newStream.Close();

                        // Invocación del servicio
                        var response = request.GetResponse();
                        var stream = response.GetResponseStream();
                        var sr = new StreamReader(stream);
                        var Resultado = sr.ReadToEnd();

                        var m = JsonConvert.DeserializeObject<List<TripulacionViewModel>>(Resultado);
                        Session["listaTripulacion"] = m;
                        //dataGridView1.DataSource = Resultado;
                        //return Task.CompletedTask;
                    }
                    //return View();


                    //----------------------------------------------------------------------------------------------------------------------------------
                    //Consulta el listado de las tripulacion con estado disponible----------------------------------------------------------------------
                    //var url = "https://localhost:7109/api/Tripulacion";
                    ////var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
                    //var request = (HttpWebRequest)WebRequest.Create(url);
                    //request.Accept = "application/json";
                    //request.ContentType = "application/json";
                    //request.Method = "GET";
                    //request.Timeout = 300000;
                    //var json = ""; //JsonConvert.SerializeObject(datos);

                    ///*ASCIIEncoding encoding = new ASCIIEncoding();
                    //Byte[] bytes = encoding.GetBytes(json);

                    //Stream newStream = request.GetRequestStream();
                    //newStream.Write(bytes, 0, bytes.Length);
                    //newStream.Close();*/

                    //// Invocación del servicio
                    //var response = request.GetResponse();
                    //var stream = response.GetResponseStream();
                    //var sr = new StreamReader(stream);
                    //var Resultado = sr.ReadToEnd();

                    //var m = JsonConvert.DeserializeObject<List<TripulacionViewModel>>(Resultado);
                    //Session["listaTripulacion"] = m;
                    ////dataGridView1.DataSource = Resultado;
                    ////return Task.CompletedTask;
                    //return View();


                    break;
                case "CrearIntegrante":
                    if (ModelState.IsValid)
                    {
                        var url = "https://localhost:7109/api/TIntegrantes";
                        //var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
                        var request = (HttpWebRequest)WebRequest.Create(url);
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        request.Timeout = 300000;
                        var json = JsonConvert.SerializeObject(datos);
                        //request.ContentLength.b = json.Length;

                        ASCIIEncoding encoding = new ASCIIEncoding();
                        Byte[] bytes = encoding.GetBytes(json);

                        Stream newStream = request.GetRequestStream();
                        newStream.Write(bytes, 0, bytes.Length);
                        newStream.Close();

                        // Invocación del servicio
                        var response = request.GetResponse();
                        var stream = response.GetResponseStream();
                        var sr = new StreamReader(stream);
                        var Resultado = sr.ReadToEnd();

                        var m = JsonConvert.DeserializeObject<List<TripulacionViewModel>>(Resultado);
                        //var d = JsonConvert.SerializeObject(Resultado,TripulacionViewModel);
                        //Session["listaTripulacion"] = m;
                        //dataGridView1.DataSource = Resultado;
                        //return Task.CompletedTask;
                    }
                    //return View();


                    //----------------------------------------------------------------------------------------------------------------------------------
                    //Consulta el listado de las tripulacion con estado disponible----------------------------------------------------------------------
                    //var url = "https://localhost:7109/api/Tripulacion";
                    ////var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
                    //var request = (HttpWebRequest)WebRequest.Create(url);
                    //request.Accept = "application/json";
                    //request.ContentType = "application/json";
                    //request.Method = "GET";
                    //request.Timeout = 300000;
                    //var json = ""; //JsonConvert.SerializeObject(datos);

                    ///*ASCIIEncoding encoding = new ASCIIEncoding();
                    //Byte[] bytes = encoding.GetBytes(json);

                    //Stream newStream = request.GetRequestStream();
                    //newStream.Write(bytes, 0, bytes.Length);
                    //newStream.Close();*/

                    //// Invocación del servicio
                    //var response = request.GetResponse();
                    //var stream = response.GetResponseStream();
                    //var sr = new StreamReader(stream);
                    //var Resultado = sr.ReadToEnd();

                    //var m = JsonConvert.DeserializeObject<List<TripulacionViewModel>>(Resultado);
                    //Session["listaTripulacion"] = m;
                    ////dataGridView1.DataSource = Resultado;
                    ////return Task.CompletedTask;
                    //return View();

            
            break;
            }
            return View();
            //public class TripulacionDto
            //{
            //    public Guid TripulacionId { get; set; }
            //    public string TripulacionNombre { get; set; }
            //    public int TripulacionEstado { get; set; }

            //}
        }
    }
}
using AeropuertoG2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace AeropuertoG2.Controllers
{
    public class VueloController : Controller
    {
        [HttpGet]
        public ActionResult AsignarVuelo()
        {
            //CARGANDO LISTA DE TRIPULANTES
            var url = "https://localhost:44365/api/Tripulacion/ListarTripulacion";
            //var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 300000;
            var json = ""; 
            // Invocación del servicio
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var Resultado = sr.ReadToEnd();
            var m = JsonConvert.DeserializeObject<List<AsignacionTripulacionViewModel>>(Resultado);
            Session["listaTripulacionAsig"] = m;


            //CARGANDO LISTA DE AERONAVES
            url = "https://localhost:44365/api/Aeronave/ListarAeronaves";
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 300000;
            json = "";
            // Invocación del servicio
            response = request.GetResponse();
            stream = response.GetResponseStream();
            sr = new StreamReader(stream);
            Resultado = sr.ReadToEnd();
            var n = JsonConvert.DeserializeObject<List<AsignarVueloAeronaveModel>>(Resultado);
            Session["listarAeronaveAsig"] = n;


            //CARGANDO LISTA DE DESTINOS VUELOS
            url = "https://localhost:44365/api/Vuelo/ListarDestinosVuelo";
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 300000;
            json = "";
            // Invocación del servicio
            response = request.GetResponse();
            stream = response.GetResponseStream();
            sr = new StreamReader(stream);
            Resultado = sr.ReadToEnd();
            var o = JsonConvert.DeserializeObject<List<AsignarDestinosVueloModel>>(Resultado);
            Session["listarDestinosVueloAsig"] = o;


            return View();
        }


        [HttpPost]
        public ActionResult AsignarVuelo(Models.principales datos, string submitButton)
        {

            AsingarVueloModel modeloVuelo = new AsingarVueloModel();
            modeloVuelo.idVuelo = datos.AsignarDestinosVueloModel.Id;
            modeloVuelo.listaItinerarios.Add(new ItinerarioVueloModel
            {
                idTripulacion = datos.AsignacionTripulacionViewModel.idTripulacion,
                idAeronave = datos.AsignarVueloAeronaveModel.Id,
                fechaHoraPartida = DateTime.Now,
                fechaHoraAbordaje = DateTime.Now,
                zonaAbordaje = "A",
                nroPuertaAbordaje = "B1",
                fechaHoraLLegada = DateTime.Now,
                tipoVuelo = "COMERCIAL"
            });



            switch (submitButton)
            {
                case "AsignarValue":
                        var url = "https://localhost:44365/api/Vuelo/AsignarVuelo";
                        //var url = "https://tripulacion20220916123257.azurewebsites.net/api/tripulacion";
                        var request = (HttpWebRequest)WebRequest.Create(url);
                        request.Accept = "application/json";
                        request.ContentType = "application/json";
                        request.Method = "POST";
                        request.Timeout = 300000;
                        var json = JsonConvert.SerializeObject(modeloVuelo);
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

                        var m = Resultado;
                        Session["idVueloAsignado"] = m;
                        //dataGridView1.DataSource = Resultado;
                        //return Task.CompletedTask;
                    break;
            }
            return View();
        }


        /*
        // GET: Vuelo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vuelo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vuelo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vuelo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vuelo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vuelo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vuelo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vuelo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */
    }
}

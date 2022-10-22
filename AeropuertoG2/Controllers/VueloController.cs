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
    public class VueloController : Controller
    {
        public ActionResult AsignarVuelo()
        {



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

using AeropuertoG2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AeropuertoG2.Controllers
{
    public class AeronaveController : Controller
    {
        // GET: Aeronave
        //invoca a pagina AeronaveIni.cshtml 
        public ActionResult AeronaveIni()
        {
            /*
            //invocar a GETALL
            var httclient = new HttpClient();
            var json = await httclient.GetStringAsync("https://localhost:44384/api/Aeronave/getall");
            var aeronaves = JsonConvert.DeserializeObject<List<Aeronave>>(json);            
            return View();
            */
                         
            var url = "https://localhost:44384/api/Aeronave/getall";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "application/json";
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Timeout = 300000;
/*
            var json = JsonConvert.SerializeObject(datos);
            //request.ContentLength.b = json.Length;

            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] bytes = encoding.GetBytes(json);

            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
*/
            // Invocación del servicio
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var Resultado = sr.ReadToEnd();

            var m = JsonConvert.DeserializeObject<List<Aeronave>>(Resultado);
            Session["listaAeronave"] = m;
            return View();
        }

        public ActionResult AeronaveCreate()
        {
            //Para cargar el dropdowlist
            ViewBag.listadoAeropuerto = ObtenerAeropuertos();
            return View();
        }

        [HttpPost]
        public ActionResult AeronaveCreate(Models.Aeronave datos, string submitButton)
        {

            //Para cargar el dropdowlist
            ViewBag.listadoAeropuerto = ObtenerAeropuertos();

            //request a endpoints
            switch (submitButton)
            {
                case "CrearAeronave":
                    if (datos.Marca != null)
                    {
                        
                        var url = "https://localhost:44384/api/Aeronave";
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

                        /*
                        var m = JsonConvert.DeserializeObject<List<Aeronave>>(Resultado);
                        Session["CreaAeronave"] = m;
                        */
                        Session["CreaAeronave"] = Resultado;
                        //dataGridView1.DataSource = Resultado;
                        //return Task.CompletedTask;
                    }                     


                    break;
                case "CrearAsientos":
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

                        var m = JsonConvert.DeserializeObject<List<Aeronave>>(Resultado);
                        //var d = JsonConvert.SerializeObject(Resultado,Aeronave);
                        //Session["listaAeronave"] = m;
                        //dataGridView1.DataSource = Resultado;
                        //return Task.CompletedTask;
                    }

                    break;
            }            

            return View();
        }
        
        public List<SelectListItem> ObtenerAeropuertos()
        {
            return new List<SelectListItem>()
            {

                new SelectListItem() {
                    Text = "AEROPUERTO INTERNACIONAL EL ALTO - LA PAZ",
                    Value = "AEROPUERTO INTERNACIONAL EL ALTO - LA PAZ"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO INTERNACIONAL JORGE WILSTERMAN - COCHABAMBA",
                    Value = "AEROPUERTO INTERNACIONAL JORGE WILSTERMAN - COCHABAMBA"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO INTERNACIONAL VIRU VIRU - SANTA CRUZ",
                    Value = "AEROPUERTO INTERNACIONAL VIRU VIRU - SANTA CRUZ"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO LA JOYA ANDINA - UYUNI",
                    Value = "AEROPUERTO LA JOYA ANDINA - UYUNI"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO DE RURRENABAQUE - RURRENABAQUE",
                    Value = "AEROPUERTO DE RURRENABAQUE - RURRENABAQUE"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO JUANA AZURDUY DE PADILLA - SUCRE",
                    Value = "AEROPUERTO JUANA AZURDUY DE PADILLA - SUCRE"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO EL TROMPILLO - SANTA CRUZ",
                    Value = "AEROPUERTO EL TROMPILLO - SANTA CRUZ"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO JUAN MENDOZA - ORURO",
                    Value = "AEROPUERTO JUAN MENDOZA - ORURO"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO CAPITAN NICOLAS ROJAS - POTOSI",
                    Value = "AEROPUERTO CAPITAN NICOLAS ROJAS - POTOSI"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO TENIENTE JORGE HENRICH ARAUZ - TRINIDAD",
                    Value = "AEROPUERTO TENIENTE JORGE HENRICH ARAUZ - TRINIDAD"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO ZELIN ZELTUN LOPEZ - RIBERALTA",
                    Value = "AEROPUERTO ZELIN ZELTUN LOPEZ - RIBERALTA"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO CAPITAN ORIEL LEA PLAZA - TARIJA",
                    Value = "AEROPUERTO CAPITAN ORIEL LEA PLAZA - TARIJA"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO CAP. GERMAN QUIROGA GUARDIA - SAN BORJA",
                    Value = "AEROPUERTO CAP. GERMAN QUIROGA GUARDIA - SAN BORJA"
                },
                new SelectListItem() {
                    Text = "AEROPUERTO DE YACUIBA - YACUIBA",
                    Value = "AEROPUERTO DE YACUIBA - YACUIBA"
                },

            };            
        }


        // GET: Aeronave/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
        // GET: Aeronave/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Aeronave/Create
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

        // GET: Aeronave/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aeronave/Edit/5
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

        // GET: Aeronave/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aeronave/Delete/5
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
    }
}

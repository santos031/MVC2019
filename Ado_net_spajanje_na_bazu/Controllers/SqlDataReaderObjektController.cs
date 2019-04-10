using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ado_net_spajanje_na_bazu.Models;

namespace Ado_net_spajanje_na_bazu.Controllers
{
    public class SqlDataReaderObjektController : Controller
    {
        // GET: SqlDataReaderObjekt
        public ActionResult Index()
        {
            //upisivanje connectionstringa u web.config
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;

            //pripremim praznu listu tecajeva
            List<Tecaj> lstTecaj = new List<Tecaj>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdTxt = "";
                cmdTxt += "SELECT * FROM [dbo].[tbltecajevi] ";

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Tecaj t1 = new Tecaj();

                        t1.Id = (int)reader["id"];
                        t1.Naziv = (string)reader["naziv"];
                        t1.Opis = (string)reader["opis"];

                        lstTecaj.Add(t1);
                    }
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            
            return View(lstTecaj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ado_net_spajanje_na_bazu.Controllers
{
    public class SqlCommandObjektController : Controller
    {
        // GET: SqlCommandObjekt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //Prvo kreiramo conn string i Connection objekt
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;
           
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Kreiramo SQL naredbu za upis u bazu
                string cmdTxt = "";
                cmdTxt += "INSERT INTO [dbo].[tbltecajevi] ([naziv], [opis]) " +
                    "VALUES ('Web desing', 'Naucite kreirati web stranice')";

                //Kreiramo Command objekt i otvaramo vezu sa bazom
                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.Connection.Open();

                //Komandu izvršavamo metodom ExecuteNonQuery
                //ako je zapis upisan u bazi, baza vraća 1 

                int brojRedaka = cmd.ExecuteNonQuery();

                if (brojRedaka > 0)
                {
                    ViewBag.Message = "Zapis je upisan u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }

        public ActionResult Edit()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {          
                string cmdTxt = "UPDATE [dbo].[tbltecajevi] "
                    + "SET "
                    + "[naziv] = 'Web dev', "
                    + "[opis] = 'Web developement' "
                    + " WHERE [dbo].[tbltecajevi].id=1";

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.Connection.Open();

                int brojRedaka = cmd.ExecuteNonQuery();

                if (brojRedaka > 0)
                {
                    ViewBag.Message = "Zapis je izmjenjen u bazi!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška - zapis nije pronađen ili nije izmjenjen!";
                }
            }
            return View("Index");
        }

        public ActionResult Delete()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdTxt = "DELETE FROM [dbo].[tbltecajevi] "
                    + " WHERE [dbo].[tbltecajevi].id=2";

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.Connection.Open();

                int brojRedaka = cmd.ExecuteNonQuery();

                if (brojRedaka > 0)
                {
                    ViewBag.Message = "Zapis je obrisan u bazi!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška - zapis nije pronađen ili nije obrisan!";
                }
            }
            return View("Index");
        }

        public ActionResult Count()
        {
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdTxt = "SELECT COUNT(*) FROM [dbo].[tbltecajevi] ";

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                cmd.Connection.Open();

                //vraća redak, u ovom slućaju samo broj zapisa
                int brojRedaka = (int)cmd.ExecuteScalar();

                if (brojRedaka > 0)
                {
                    ViewBag.Message = "U tablici se nalazi" + brojRedaka + " zapisa!";
                }
                else
                {
                    ViewBag.Message = "Tablica je prazna!";
                }
            }
            return View("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ado_net_spajanje_na_bazu.Controllers
{
    public class SqlConnectionObjectController : Controller
    {
        // GET: SqlConnectionObject direktno
        public ActionResult Index()
        {
            //Prvo kreiramo conn string
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";

            //Nakon toga instanca Sqlconnection
            SqlConnection conn = new SqlConnection(connString);

            //Otvaramo vezu sa bazom
            try
            {
                conn.Open();
                //AKo je veza otvorena, uspjeli smo se spojiti

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela.");
                }
            }
            catch (SqlException sqlex)
            { 
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                //U slucaju da konekcija nije uspjela, ispisujemo poruku o greški
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                //Kad obavimo sve operacije u bazi, konekciju uvijek treba zatvoriti
                conn.Close();
            }

            return View();
        }
        // GET: SqlConnectionObject preko Web.config
        public ActionResult SpojPrekoWebConfig()
        {
            //Prvo kreiramo conn string
            // string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;

            //Nakon toga instanca Sqlconnection
            SqlConnection conn = new SqlConnection(connString);

            //Otvaramo vezu sa bazom
            try
            {
                conn.Open();
                //AKo je veza otvorena, uspjeli smo se spojiti

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela.");
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                //U slucaju da konekcija nije uspjela, ispisujemo poruku o greški
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                //Kad obavimo sve operacije u bazi, konekciju uvijek treba zatvoriti
                conn.Close();
            }

            return View();
        }
    }
}

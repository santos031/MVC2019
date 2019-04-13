using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADO_NET_komponente.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_komponente.Controllers
{
    public class ADONETKomponenteController : Controller
    {
        public static string connStr = 
            ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;

        // GET: ADONETKomponente
        public ActionResult List()
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPolaznici";

            SqlDataReader dr = null;
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();

            try
            {
                conn.Open();
                dr = cm.ExecuteReader();

                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PolaznikModel polaznik = new PolaznikModel();
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Ime = dr["Prezime"].ToString();
                            polaznik.Ime = dr["Email"].ToString();
                            polaznik.DatumRodjenja =
                                DateTime.Parse(dr["DatumRodjenja"].ToString());
                            lstPolaznici.Add(polaznik);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika!" + ex.Message;
            }
            finally
            {
                if( dr!= null)
                {
                    dr.Close();
                }
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cm.Dispose();
            }
            return View(lstPolaznici);
        }

        [HttpPost]
        public ActionResult Details(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            string cmdText = "SELECT * FROM tblPolaznici WHERE IdPolaznik=@IdPolaznik";

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPolaznik";
            param.DbType = DbType.Int32;
            param.Direction = ParameterDirection.Input;
            param.Value = idPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Ime = dr["Prezime"].ToString();
                            polaznik.Ime = dr["Email"].ToString();
                            polaznik.DatumRodjenja =
                                DateTime.Parse(dr["DatumRodjenja"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika!" + ex.Message;
            }
            finally
            {
                if ( dr != null)
                {
                    dr.Close();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }

        [HttpPost]
        public ActionResult Create()
        {
            return View(new PolaznikModel());
        }

        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            public static string connStr =
            ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;

            try
            {
                using(SqlConnection conm = new SqlConnection(connStr))
                {
                   string cmdText = "";
                    cmdText +="INSERT INTO tblPolaznici ";
            cmdText += "(Ime, Prezime, Email, DatumRodjenja) ";
            
            }
    }
}
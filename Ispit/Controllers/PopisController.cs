using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Ispit.Models;

namespace Ispit.Controllers
{
    public class PopisController : Controller
    {
        // public string KucniconnString = @"Data Source = SKYNET\SQLEXPRESS; Initial Catalog = BozicniPokloni; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True;";
        public string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BozicniPokloni;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string cmdTxt = "";
        public SqlConnection conn;

        // GET: Popis
        public ActionResult Index()
        {
            List<Pokloni> lstPokloni = new List<Pokloni>();

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija uspjela.");

                    {
                        cmdTxt = "SELECT * FROM [dbo].[pokloni] ";

                        SqlCommand cmd = new SqlCommand(cmdTxt, conn);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Pokloni p = new Pokloni();

                                p.Id = (int)reader["id"];
                                p.Naziv = (string)reader["naziv"];
                                p.Ime = (string)reader["ime"];
                                p.Stanje = (bool)reader["stanje"];

                                lstPokloni.Add(p);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Nema zapisa!";
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(lstPokloni);
        }

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Detalji o poklonu";

            Pokloni poklon = new Pokloni();

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                cmdTxt = "SELECT top 1 * FROM [dbo].[pokloni] where id = " + id;

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                //cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        poklon.Id = (int)reader["id"];
                        poklon.Ime = (string)reader["ime"];
                        poklon.Naziv = (string)reader["naziv"];
                        poklon.Stanje = (bool)reader["stanje"];
                    }
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(poklon);
            //return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Unos poklona";

            return View();
        }

        [HttpPost]
        public ActionResult Create(Pokloni pokloni)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //Kreiramo SQL naredbu za upis u bazu
                    cmdTxt = "INSERT INTO [dbo].[pokloni] ([naziv],[ime],[stanje]) " +
                        "VALUES ('" + pokloni.Naziv + "', '" + pokloni.Ime + "', " + Convert.ToInt32(pokloni.Stanje) + ")";

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

            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Izmjena poklona";
            Pokloni poklon = new Pokloni();

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                cmdTxt = "SELECT top 1 * FROM [dbo].[pokloni] where id = " + id;

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                //cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        poklon.Id = (int)reader["id"];
                        poklon.Ime = (string)reader["ime"];
                        poklon.Naziv = (string)reader["naziv"];
                        poklon.Stanje = (bool)reader["stanje"];
                    }
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(poklon);
        }

        [HttpPost]
        public ActionResult Edit(Pokloni pokloni)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    //Kreiramo SQL naredbu za upis u bazu
                    cmdTxt = "UPDATE pokloni SET naziv = '" + pokloni.Naziv + "', ime = '" + pokloni.Ime + "',stanje = " + Convert.ToInt32(pokloni.Stanje) + " where id = "+ pokloni.Id;

                    //Kreiramo Command objekt i otvaramo vezu sa bazom
                    SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                    cmd.Connection.Open();

                    //Komandu izvršavamo metodom ExecuteNonQuery
                    //ako je zapis upisan u bazi, baza vraća 1 

                    int brojRedaka = cmd.ExecuteNonQuery();

                    if (brojRedaka > 0)
                    {
                        ViewBag.Message = "Zapis je izmjenjen u bazu!";
                    }
                    else
                    {
                        ViewBag.Message = "Dogodila se greška!";
                    }
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
               // conn.Close();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Pokloni poklon = new Pokloni();

            try
            {

                conn = new SqlConnection(connString);
                conn.Open();

                cmdTxt = "SELECT top 1 * FROM [dbo].[pokloni] where id = " + id;

                SqlCommand cmd = new SqlCommand(cmdTxt, conn);
                //cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        poklon.Id = (int)reader["id"];
                        poklon.Ime = (string)reader["ime"];
                        poklon.Naziv = (string)reader["naziv"];
                        poklon.Stanje = (bool)reader["stanje"];
                    }
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write("Greška sapajanja sa bazom" + sqlex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("Neka greška" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(poklon);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Pokloni pokloni)
        {
            //string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;

            {
                using (conn = new SqlConnection(connString))

                //                cmdTxt = "DELETE FROM [dbo].[pokloni] "
                //                    + " WHERE id=" + pokloni.Id;

                using (var cmd1 = new SqlCommand("DELETE FROM pokloni WHERE id = @id", conn))
                {
                    cmd1.Parameters.Add("@id", SqlDbType.Int).Value = pokloni.Id;
                    conn.Open();
                    int brojRedaka = cmd1.ExecuteNonQuery();

                    if (brojRedaka > 0)
                    {
                        ViewBag.Message = "Zapis je obrisan u bazi!";
                    }
                    else
                    {
                        ViewBag.Message = "Dogodila se greška - zapis nije pronađen ili nije obrisan!";
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}

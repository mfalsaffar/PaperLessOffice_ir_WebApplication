using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using PaperLessOffice_ir_WebApplication.Models;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class MyJobController : Controller
    {
        public ActionResult Index(int userId)
        {
            try                                         
            {
                List<MyJobViewModel> jobs = new List<MyJobViewModel>();

                using (SqlConnection connection = new SqlConnection("DefaultConnection"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Pro_GetMyJob", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("1", userId); // USER mahdi = 1
                        //command.Parameters.AddWithValue("@userid", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MyJobViewModel job = new MyJobViewModel
                                {
                                    Fullname = reader.GetString(reader.GetOrdinal("fullname")),
                                    ProcName = reader.GetString(reader.GetOrdinal("procname")),
                                    WfId = reader.GetInt32(reader.GetOrdinal("wfid"))
                                    // Add other properties as needed
                                };
                                jobs.Add(job);
                            }
                        }
                    }
                }

                return View(jobs);
            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                return View("Error");
            }
        }
    }
}

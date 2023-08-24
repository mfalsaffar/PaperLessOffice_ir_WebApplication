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
                List<ProGetMyJobResponse> jobs = new List<ProGetMyJobResponse>();

                using (SqlConnection connection = new SqlConnection("DefaultConnection"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Pro_GetMyJob", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userid", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProGetMyJobResponse job = new ProGetMyJobResponse
                                {
                                    Fullname = reader.GetString(reader.GetOrdinal("fullname")),
                                    ProcName = reader.GetString(reader.GetOrdinal("procname")),
                                    WfId = reader.GetInt64(reader.GetOrdinal("wfid")),
                                    ProcId = reader.GetInt64(reader.GetOrdinal("procid")),
                                    WfStatus = reader.GetString(reader.GetOrdinal("wfstatus")),
                                    TimeJobStart = reader.GetDateTime(reader.GetOrdinal("timeJobStart")),
                                    AlarmTime = reader.GetDateTime(reader.GetOrdinal("alarmtime")),
                                    Doc = reader.GetString(reader.GetOrdinal("doc")),
                                    WfCurrentJob = reader.GetInt64(reader.GetOrdinal("wfcurrentjob")),
                                    WfStatusCode = reader.GetInt32(reader.GetOrdinal("wfstatusCode")),
                                    JobName = reader.GetString(reader.GetOrdinal("jobname"))
                                };
                                jobs.Add(job);
                            }
                        }
                    }
                }

                return View(jobs);
            }
            catch (Exception)
            {
                // Handle exceptions if needed
                return View("Error");
            }
        }
    }
}

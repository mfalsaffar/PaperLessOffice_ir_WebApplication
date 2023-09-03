using PaperLessOffice_ir_WebApplication.Models;
using PaperLessOffice_ir_WebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Main()
        {
            // First Segment - Pro_GetMyJobShortList
            List<JobShortInfo> jobShortList = new List<JobShortInfo>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Pro_GetMyJobShortList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", 5);  // 5 should be the session of the user passed @userid ***
                    command.Parameters.AddWithValue("@Sort", 2);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            JobShortInfo jobInfo = new JobShortInfo
                            {
                                JobId = reader.GetInt64(reader.GetOrdinal("wfcurrentjob")),
                                JobName = (string)reader["jobname"],
                                Total = (int)reader["total"]
                            };

                            jobShortList.Add(jobInfo);
                        }
                    }
                }
            }

            ViewBag.JobShortInfo = jobShortList;

            // Second Segment - Pro_GetMyJob
            List<DetailedJobInfo> detailedJobList = new List<DetailedJobInfo>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Pro_GetMyJob", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@userid", 5); // 5 should be the session of the user passed @userid ***

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetailedJobInfo detailedJobInfo = new DetailedJobInfo
                            {
                                FullName = (string)reader["fullname"],
                                ProcName = (string)reader["procname"],
                                WFId = reader.GetInt64(reader.GetOrdinal("wfid")),
                                ProcId = reader.GetInt64(reader.GetOrdinal("procid")),
                                WFStatus = (string)reader["wfstatus"],
                                TimeJobStart = (DateTime)reader["timeJobStart"],
                                AlarmTime = (DateTime)reader["alarmtime"],
                                Doc = (string)reader["doc"],
                                WFCurrentJob = reader.GetInt64(reader.GetOrdinal("wfcurrentjob")),
                                WFStatusCode = (int)reader["wfstatusCode"]
                            };

                            detailedJobList.Add(detailedJobInfo);
                        }
                    }
                }
            }

            ViewBag.DetailedJobInfo = detailedJobList;

            return View();
        }


        // Other action methods and code...

        [HttpGet]
        public JsonResult GetDetailedJobInfo(long jobId)
        {
            try
            {
                List<DetailedJobInfo> detailedJobInfo = new List<DetailedJobInfo>();

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("Pro_GetMySpecificJob", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@jobId", jobId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DetailedJobInfo jobInfo = new DetailedJobInfo
                                {
                                    FullName = (string)reader["fullname"],
                                    ProcName = (string)reader["procname"],
                                    WFId = reader.GetInt64(reader.GetOrdinal("wfid")),
                                    ProcId = reader.GetInt64(reader.GetOrdinal("procid")),
                                    WFStatus = (string)reader["wfstatus"],
                                    TimeJobStart = (DateTime)reader["timeJobStart"],
                                    AlarmTime = (DateTime)reader["alarmtime"],
                                    Doc = (string)reader["doc"],
                                    WFCurrentJob = reader.GetInt64(reader.GetOrdinal("wfcurrentjob")),
                                    WFStatusCode = (int)reader["wfstatusCode"]
                                };

                                detailedJobInfo.Add(jobInfo);
                            }
                        }
                    }
                }

                return Json(detailedJobInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return Json(new { error = "An error occurred while retrieving detailed job information." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
 }






//-----------------------------------------------------------segment 1 working
//using PaperLessOffice_ir_WebApplication.Models;
//using PaperLessOffice_ir_WebApplication.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Data;

//namespace PaperLessOffice_ir_WebApplication.Controllers
//{
//    public class MainController : Controller
//    {
//        public ActionResult Main()
//        {
//            List<JobShortInfo> jobShortList = new List<JobShortInfo>();

//            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
//            {
//                connection.Open();

//                using (SqlCommand command = new SqlCommand("Pro_GetMyJobShortList", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@userid", 5);
//                    command.Parameters.AddWithValue("@Sort", 2);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            JobShortInfo jobInfo = new JobShortInfo
//                            {
//                                JobId = reader.GetInt64(reader.GetOrdinal("wfcurrentjob")),  //JobId = (long)reader["wfcurrentjob"],
//                                JobName = (string)reader["jobname"],
//                                Total = (int)reader["total"]
//                            };

//                            jobShortList.Add(jobInfo);
//                        }
//                    }
//                }
//            }

//            ViewBag.JobShortInfo = jobShortList; // Set the ViewBag here

//            return View(); // Return the view without passing any model
//        }
//    }

//}

using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.SqlClient;
using Paginationproject.Models;
using System;
using System.Configuration;

namespace Paginationproject.Controllers
{
    public class PaginationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Display()
        {
            List<PaginationModel> employee = new List<PaginationModel>();
            try
            {
                DBModel data = new DBModel();
                SqlConnection connection = data.DBconnection();
                connection.Open();
                string sql = "SELECT * FROM PaginationTable";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                PaginationModel details;

                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        details = new PaginationModel();
                        details.EmployeeId = int.Parse(read["EmployeeId"].ToString());
                        details.FirstName = (read["FirstName"].ToString());
                        details.LastName = read["LastName"].ToString();
                        details.EmailId = read["EmailId"].ToString();
                        details.ProjectId = int.Parse(read["ProjectId"].ToString());
                        details.ProjectName = read["ProjectName"].ToString();
                        employee.Add(details);

                    }
                }
            }
            catch (Exception e)
            {

            }
            return Json(employee,JsonRequestBehavior.AllowGet);
        }
    }
}

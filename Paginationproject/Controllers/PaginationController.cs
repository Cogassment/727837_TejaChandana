using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data.SqlClient;
using Paginationproject.Models;

namespace Paginationproject.Controllers
{
    public class PaginationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\727837\source\repos\Paginationproject\Paginationproject\App_Data\Empdatabase.mdf;Integrated Security=True");
            con.Open();
            string sql = "SELECT * FROM PaginationTable";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            List<PaginationModel> employee = new List<PaginationModel>();
            PaginationModel details;

            using (SqlDataReader read = cmd.ExecuteReader())
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
            return Json(employee);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 百度UEditor的使用.Models;

namespace 百度UEditor的使用.Controllers
{
    public class HomeController : Controller
    {
        public string constr = "Data Source=.;Initial Catalog=test1;Integrated Security=True";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // 图片上传
        public void uploadimage()
        {
        }

        // 根据id获取文章
        public ActionResult GetContentById(int id)
        {
            DataTable dt = new DataTable();
            List<Article> list = new List<Article>();
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                string sql = "";

                sql = "select * from articles where id=" + id;


                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    int id2 = Convert.ToInt32(row["Id"]);
                    string title = row["title"].ToString();
                    string content = row["article"].ToString();

                    Article a = new Article();
                    a.Id = id2;
                    a.Title = title;
                    a.Content = content;

                    list.Add(a);
                }
            }
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }

        // 没有图片的提交
        [ValidateInput(false)]
        public ActionResult Upload(string title, string content)
        {
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                string sql = string.Format("insert into articles(title,article) values('{0}','{1}')", title, content);
                cmd.CommandText = sql;
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return Content("Ok");
                }
            }
            return Content("error");
        }

        // 列表展示
        public ActionResult List()
        {
            DataTable dt = new DataTable();
            List<Article> list = new List<Article>();
            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = con.CreateCommand())
            {
                con.Open();
                string sql = "";

                sql = "select * from articles";



                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string title = row["title"].ToString();
                    string content = row["article"].ToString();

                    Article a = new Article();
                    a.Id = id;
                    a.Title = title;
                    a.Content = content;

                    list.Add(a);
                }
                ViewBag.articles = list;
            }
            return View();
        }
    }
}
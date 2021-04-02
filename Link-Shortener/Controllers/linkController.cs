using Dapper;
using Link_Shortener.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Link_Shortener.Controllers
{
    public class linkController : Controller
    {
        public ActionResult view(int id)
        {
            List<Link> linkList;
            Link link;
            using (IDbConnection cnn = new SqlConnection(connString()))
            {
                string sql = "SELECT linkFrom,linkTo FROM dbo.Links WHERE linkFrom="+id;
                linkList = cnn.Query<Link>(sql).ToList();
            }
            link = linkList[0];
            return View(link);
        }

        public ActionResult create()
        {
            return View();
        }

        public string connString() => ConfigurationManager.ConnectionStrings["db1"].ConnectionString;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(Link link)
        {
            
            List<int> idList = new List<int>();
            string sql = @"SELECT linkFrom FROM dbo.Links";
            string sql1 = @"INSERT INTO dbo.Links (linkFrom, linkTo) VALUES (@linkFrom, @linkTo)";
            using (IDbConnection cnn = new SqlConnection(connString()))
            {
                int linkFromInt = 999;
                idList = cnn.Query<int>(sql).ToList();
                idList.Sort();
                for (int x = 0; x < 999; x++)
                {
                    if (!idList.Contains(x))
                    {
                        linkFromInt = x;
                        break;
                    }
                }
                link.linkFrom = linkFromInt;
                cnn.Execute(sql1, link);
            }

            return View(link);
        }
    }
}
using AngularUIGrid.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace AngularUIGrid.Web.Controllers
{
    public class ProductController : Controller
    {
        private dbUIGrid_Entities _ctx = null;
        public JsonResult GetProducts(int pageNumber, int pageSize)
        {
            object result = null;
            try
            {
                using (_ctx = new dbUIGrid_Entities())
                {
                    result = new
                    {
                        recordsTotal = _ctx.tblProducts.Count(),
                        productList = _ctx.tblProducts.OrderBy(x => x.ProductID)
                                         .Skip(pageNumber)
                                         .Take(pageSize)
                                         .ToList()
                    };
                }
            }
            catch (Exception)
            {
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using OutdoorOrders.WebService.Models;
using OutdoorOrders.WebService.Tools;

namespace OutdoorOrders.WebService.Controllers
{
    public class ProductsCategoriesController : BaseController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<ProductsCategories> Get()
        {
            var model = db.ProductsCategories;
            return model;
        }

        [HttpGet]
        public int Count(ODataQueryOptions<ProductsCategories> QueryOptions)
        {
            return this.GetNumericValue<ProductsCategories, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<ProductsCategories> QueryOptions)
        {
            return this.GetNumericValue<ProductsCategories, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<ProductsCategories> QueryOptions)
        {
            return this.GetNumericValue<ProductsCategories, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(ProductsCategories entity)
        {
            try
            {
                db.ProductsCategories.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(ProductsCategories entity)
        {
            try
            {
                db.ProductsCategories.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var model = db.ProductsCategories.Where(f => f.CategoryID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.ProductsCategories.Attach(model);
                db.Entry(model).State = EntityState.Deleted;
                db.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
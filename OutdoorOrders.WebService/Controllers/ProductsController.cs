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
    public class ProductsController : BaseController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<Products> Get()
        {
            var model = db.Products;
            return model;
        }

        [HttpGet]
        public int Count(ODataQueryOptions<Products> QueryOptions)
        {
            return this.GetNumericValue<Products, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<Products> QueryOptions)
        {
            return this.GetNumericValue<Products, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<Products> QueryOptions)
        {
            return this.GetNumericValue<Products, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(Products entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(Products entity)
        {
            try
            {
                db.Products.Attach(entity);
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
                var model = db.Products.Where(f => f.ProductID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.Products.Attach(model);
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
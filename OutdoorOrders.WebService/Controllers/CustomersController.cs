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
    public class CustomersController : BaseController
    {
       
        [HttpGet]
        [EnableQuery]
        public IQueryable<Customers> Get()
        {
            var model = db.Customers;
            return model;
        }

        [HttpGet]
        public int Count(ODataQueryOptions<Customers> QueryOptions)
        {
            return this.GetNumericValue<Customers, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<Customers> QueryOptions)
        {
            return this.GetNumericValue<Customers, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<Customers> QueryOptions)
        {
            return this.GetNumericValue<Customers, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(Customers entity)
        {
            try
            {
                db.Customers.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(Customers entity)
        {
            try
            {
                db.Customers.Attach(entity);
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
                var model = db.Customers.Where(f => f.CustomerID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.Customers.Attach(model);
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
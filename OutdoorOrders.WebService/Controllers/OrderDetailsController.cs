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
    public class OrderDetailsController : BaseController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<OrderDetails> Get()
        {
            var model = db.OrderDetails;
            return model;
        }

        [HttpGet]
        public int Count(ODataQueryOptions<OrderDetails> QueryOptions)
        {
            return this.GetNumericValue<OrderDetails, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<OrderDetails> QueryOptions)
        {
            return this.GetNumericValue<OrderDetails, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<OrderDetails> QueryOptions)
        {
            return this.GetNumericValue<OrderDetails, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(OrderDetails entity)
        {
            try
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(OrderDetails entity)
        {
            try
            {
                db.OrderDetails.Attach(entity);
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
                var model = db.OrderDetails.Where(f => f.OrderDetailID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.OrderDetails.Attach(model);
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
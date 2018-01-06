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
    public class SalespersonsController : BaseController
    {
        [HttpGet]
        [EnableQuery]
        public IQueryable<Salespersons> Get()
        {
            var model = db.Salespersons;
            return model;
        }

        [HttpGet]
        public int Count(ODataQueryOptions<Salespersons> QueryOptions)
        {
            return this.GetNumericValue<Salespersons, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<Salespersons> QueryOptions)
        {
            return this.GetNumericValue<Salespersons, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<Salespersons> QueryOptions)
        {
            return this.GetNumericValue<Salespersons, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(Salespersons entity)
        {
            try
            {
                db.Salespersons.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(Salespersons entity)
        {
            try
            {
                db.Salespersons.Attach(entity);
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
                var model = db.Salespersons.Where(f => f.SalespersonID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.Salespersons.Attach(model);
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
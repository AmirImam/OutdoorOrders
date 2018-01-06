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
    public class CustomersBranchesController : BaseController
    {
        //This Is SourceControl Test
        [HttpGet]
        [EnableQuery]
        public IQueryable<CustomersBranches> Get()
        {
            var model = db.CustomersBranches;
            return model;
        }
        
        [HttpGet]
        public int Count(ODataQueryOptions<CustomersBranches> QueryOptions)
        {
            return this.GetNumericValue<CustomersBranches, int>(QueryOptions, AggregationTypes.Count);
        }
        [HttpGet]
        public decimal Sum(ODataQueryOptions<CustomersBranches> QueryOptions)
        {
            return this.GetNumericValue<CustomersBranches, decimal>(QueryOptions, AggregationTypes.Sum);
        }
        [HttpGet]
        public decimal Max(ODataQueryOptions<CustomersBranches> QueryOptions)
        {
            return this.GetNumericValue<CustomersBranches, decimal>(QueryOptions, AggregationTypes.Max);
        }

        [HttpPost]
        public IHttpActionResult Post(CustomersBranches entity)
        {
            try
            {
                db.CustomersBranches.Add(entity);
                db.SaveChanges();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPut]
        public IHttpActionResult Put(CustomersBranches entity)
        {
            try
            {
                db.CustomersBranches.Attach(entity);
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
                var model = db.CustomersBranches.Where(f => f.CustomerBranchID == id).FirstOrDefault();
                if (model == null)
                    return NotFound();

                db.CustomersBranches.Attach(model);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using OutdoorOrders.WebService.Models;
using System.Web.Http.OData.Query;

namespace OutdoorOrders.WebService.Tools
{
    public enum AggregationTypes
    {
        Count,
        Sum,
        Max
    }
    public abstract class BaseController : ApiController
    {
        protected OrdersEntities db = new OrdersEntities();
        protected TNumber GetNumericValue<TModel,TNumber>(ODataQueryOptions QueryOptions,AggregationTypes aggregationType)  where TNumber:IComparable
        {
            string keyWord = string.Empty;
            switch (aggregationType)
            {
                case AggregationTypes.Count:
                    keyWord = "COUNT";
                    break;
                case AggregationTypes.Sum:
                    keyWord = "SUM";
                    break;
                case AggregationTypes.Max:
                    keyWord = "MAX";
                    break;
                default:
                    break;
            }
            
            string column = this.GetSelection(QueryOptions);
            string condition = this.GetFilter(QueryOptions);
            var count = db.Database.SqlQuery<TNumber>("Select " + keyWord + "(" + column + ") From " + typeof(TModel).Name + " " + condition);
            return (TNumber)count.FirstOrDefault();
        }

        private string GetFilter(ODataQueryOptions options)
        {
            string filter = options.Filter == null ? "" : " WHERE " + options.Filter.RawValue.OdataFilterToSqlCondition();

            return filter;
        }

        private string GetSelection(ODataQueryOptions options)
        {
            string selection = options.SelectExpand.RawSelect;
            return selection;
        }
    }
}
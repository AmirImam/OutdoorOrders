using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutdoorOrders.WebService.Tools
{
    public static class Extensions
    {
        public static string OdataFilterToSqlCondition(this string filter)
        {
            string result = filter.Replace(" eq ", " = ")
                .Replace(" gt ", " > ")
                .Replace(" lt ", " < ")
                .Replace(" ge ", " >= ")
                .Replace(" le ", " <= ");
            return result;
        }
    }
}
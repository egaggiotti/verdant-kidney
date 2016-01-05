using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Web.Services
{
    public class HttpServiceHelper
    {
        public TResult Post<TConvertType, TResult>(TConvertType item, string uriPart, string uriBase)
        {
            return default(TResult);
        }
    }
}
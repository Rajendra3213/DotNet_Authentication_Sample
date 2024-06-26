using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAppUsingADO
{
    public static class ConnectionString
    {
        private static string cs = "Server=.;Database=CrudADOdb;User Id=SA;Password=Password123;TrustServerCertificate=true";
        public static string Dbcs { get => cs; }
    }
}

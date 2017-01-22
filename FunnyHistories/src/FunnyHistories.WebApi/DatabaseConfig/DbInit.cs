using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyHistories.WebApi.DatabaseConfig
{
    public static class DbInit
    {
        public static void Initialize(FunnyHistoryContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

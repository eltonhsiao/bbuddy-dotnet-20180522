using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GOOS_Sample.Interface;
using GOOS_Sample.Repositories;

namespace GOOS_Sample.Factories
{
    public static class RepositoryFactory
    {
        //private static Lazy<IGOOSRepo> goosRepo = new Lazy<IGOOSRepo>(
        //    () =>
        //    {
        //        var dbContext = TiDbContextFactory.GetDbConfig(DbRole.VirtualSportsDb);

        //        return new GOOSRepo(dbContext);
        //    });

        //public static IGOOSRepo GOOSRepo
        //{
        //    get
        //    {
        //        return goosRepo.Value;
        //    }
        //}
    }
}
/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Microsoft.AspNetCore.TestHost
  --*                   Microsoft.AspNetCore.Hosting
  --*                   Microsoft.Extensions.Configuration
  --* Description     : Catalog item scenario base
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/12/23  CR-XXXXX Original
  --****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Catalog.FunctionalTests
{
    public class CatalogItemScenariosBase
    {
        public TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(CatalogItemScenariosBase)).Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                })
                .UseStartup<Program>();

            var testServer = new TestServer(hostBuilder);

            return testServer;
        }

        public static class Get
        {
            private const int PAGE_INDEX = 0;
            private const int PAGE_COUNT = 4;

            public static string Items(bool paginated = false)
            {
                return paginated
                    ? "https://localhost:5001/api/v1/Items" + Paginated(PAGE_INDEX, PAGE_COUNT)
                    : "https://localhost:5001/api/v1/Items";
            }

            public static string ItemById(Guid id)
            {
                return $"https://localhost:5001/api/v1/Items/{id}";
            }

            private static string Paginated(int pageIndex, int pageCount)
            {
                return $"?pageIndex={pageIndex}&pageSize={pageCount}";
            }
        }
    }
}

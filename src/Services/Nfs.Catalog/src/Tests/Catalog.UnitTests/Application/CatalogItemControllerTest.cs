using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Nfs.Catalog.Service.Domain;
using Nfs.Catalog.Service.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.UnitTests.Application
{
    public class CatalogItemControllerTest
    {
        #region Ctor

        public CatalogItemControllerTest()
        {
        }

        #endregion

        #region Methods

        [Fact]
        public async Task Get_catalog_items_success()
        {
        }

        private List<Item> GetFakeCatalogItem()
        {
            return new List<Item>()
            {
                new()
                {
                    Name = "fakeItemA",
                    Description = "Bar",
                    Price = 1,
                    CreatedDate = DateTime.Now,
                },
                new()
                {
                    Name = "fakeItemB",
                    Description = "Coke",
                    Price = 3,
                    CreatedDate = DateTime.Now,
                },
                new()
                {
                    Name = "fakeItemC",
                    Description = "Choco",
                    Price = 4,
                    CreatedDate = DateTime.Now,
                },
                new()
                {
                    Name = "fakeItemD",
                    Description = "FStar",
                    Price = 9,
                    CreatedDate = DateTime.Now,
                },
                new()
                {
                    Name = "fakeItemE",
                    Description = "MiniBar",
                    Price = 10,
                    CreatedDate = DateTime.Now,
                }
            };
        }

        #endregion
    }
}
/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : NA
  --* Description     : Catalog service functional test cases
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/12/23  CR-XXXXX Original
  --****************************************************************************/
namespace Catalog.FunctionalTests
{
    /// <summary>
    /// Represents catalog item functional test scenarios
    /// </summary>
    public class CatalogItemScenarios : CatalogItemScenariosBase
    {
        [Fact]
        public async Task Get_get_all_catalogitems_and_response_ok_status_code()
        {
            using var server = CreateServer();
            var client = server.CreateClient();
            var response = await client.GetAsync(Get.Items());

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_get_catalogitem_by_id_and_response_ok_status_code()
        {
            using var server = CreateServer();
            var response = await server.CreateClient().GetAsync(Get.ItemById(new Guid("018e8408-570c-46a5-9927-2173d35455f4")));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Get_get_catalogitem_by_id_and_response_bad_request_status_code()
        {
            // Arrange
            using var server = CreateServer();
            var response = await server.CreateClient().GetAsync(Get.ItemById(Guid.Empty));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_get_catalogitem_by_id_and_response_not_found_status_code()
        {
            // Arrange
            using var server = CreateServer();
            var response = await server.CreateClient().GetAsync(Get.ItemById(Guid.Empty));

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
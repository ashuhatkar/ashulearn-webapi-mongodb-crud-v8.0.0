/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Nfs.Catalog.Services.Domain
  --*                   Nfs.Catalog.Service.Models
  --* Description     : Mapper extensions
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using Nfs.Catalog.Service.Domain;
using Nfs.Catalog.Service.Models;

namespace Nfs.Catalog.Service.Infrastructure.Mapper.Extensions
{
    /// <summary>
    /// Represents the extensions to map entity to model and vice versa
    /// </summary>
    public static class MapperExtensions
    {
        #region Methods

        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            };
        }

        #endregion
    }
}
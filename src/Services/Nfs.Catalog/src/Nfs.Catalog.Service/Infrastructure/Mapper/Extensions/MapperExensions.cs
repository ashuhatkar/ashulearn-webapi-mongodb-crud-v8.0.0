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
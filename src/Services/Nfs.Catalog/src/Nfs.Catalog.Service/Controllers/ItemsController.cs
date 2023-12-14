/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : Microsoft.AspNetCore.Mvc ...
  --* Description     : Items controller
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nfs.Catalog.Service.Domain;
using Nfs.Catalog.Service.Infrastructure.Mapper.Extensions;
using Nfs.Catalog.Service.Models;
using Nfs.Common;

namespace Nfs.Catalog.Service.Controllers
{
    /// <summary>
    /// Represents a catalog api controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public partial class ItemsController : BaseApiController
    {
        #region Fields

        private readonly IRepository<Item> _itemsRepository;

        #endregion

        #region Ctor

        public ItemsController(IRepository<Item> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets list of catalog items
        /// </summary>
        /// <returns>Catalog list model</returns>
        /// GET api/v1/Items
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<ItemDto>>> GetAsync()
        {
            var items = (await _itemsRepository.GetAllAsync())
                .Select(item => item.AsDto());

            return Ok(items);
        }

        /// <summary>
        /// Gets a catalog item
        /// </summary>
        /// <param name="id">Catalog identifier</param>
        /// <returns>Catalog item</returns>
        /// GET api/v1/Items/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item.AsDto());
        }

        /// <summary>
        /// Inserts a catalog item
        /// </summary>
        /// <param name="createItemDto">Create item dto model</param>
        /// <returns>Catalog item</returns>
        //POST /items
        [HttpPost]
        public virtual async Task<IActionResult> PostAsync([FromBody] CreateItemDto createItemDto)
        {
            var item = new Item()
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            await _itemsRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        /// <summary>
        /// Update catalog item
        /// </summary>
        /// <param name="id">Catalog item identifier</param>
        /// <param name="updateItemDto">Update item dto model</param>
        /// <returns>Catalog item</returns>
        //PUT /items/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateItemDto updateItemDto)
        {
            var existingItem = await _itemsRepository.GetByIdAsync(id);

            if (existingItem == null || updateItemDto == null)
                return NotFound();

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await _itemsRepository.UpdateAsync(existingItem);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = existingItem.Id }, existingItem);
        }

        /// <summary>
        /// Deletes a catalog item
        /// </summary>
        /// <param name="id">Catalog identifier</param>
        /// <returns>Task</returns>
        //DELETE /items/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var item = await _itemsRepository.GetByIdAsync(id);

            if (item == null)
                return NotFound();

            await _itemsRepository.DeleteAsync(item.Id);

            return NoContent();
        }

        #endregion
    }
}
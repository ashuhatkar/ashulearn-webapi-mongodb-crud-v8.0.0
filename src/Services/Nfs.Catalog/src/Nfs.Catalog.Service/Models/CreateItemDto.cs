/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System.ComponentModel.DataAnnotation
  --* Description     : Create item dto model
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System.ComponentModel.DataAnnotations;

namespace Nfs.Catalog.Service.Models
{
    /// <summary>
    /// Represents create item dto
    /// </summary>
    public partial record CreateItemDto
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        [DataType(DataType.Currency)]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}
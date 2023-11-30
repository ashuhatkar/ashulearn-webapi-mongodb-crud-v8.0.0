/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System
  --* Description     : Item dto model
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;

namespace Nfs.Catalog.Service.Models
{
    /// <summary>
    /// Represents item dto model
    /// </summary>
    public partial record ItemDto
    {
        /// <summary>
        /// Gets or sets identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public DateTimeOffset CreatedDate { get; set; }
    }
}
/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System, Nfs.Common
  --* Description     : Item domain entity
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;
using Nfs.Common;

namespace Nfs.Catalog.Service.Domain
{
    /// <summary>
    /// Represents an catalog item
    /// </summary>
    public partial class Item : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description
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
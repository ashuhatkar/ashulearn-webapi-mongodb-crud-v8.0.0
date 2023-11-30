/*--****************************************************************************
  --* Project Name    : WebApi-MongoDB-CRUD
  --* Reference       : System
  --* Description     : Base entity
  --* Configuration Record
  --* Review            Ver  Author           Date      Cr       Comments
  --* 001               001  A HATKAR         15/11/23  CR-XXXXX Original
  --****************************************************************************/
using System;

namespace Nfs.Common
{
    /// <summary>
    /// Represents the base class for domain entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets guid identifier
        /// </summary>
        public Guid Id { get; set; }
    }
}
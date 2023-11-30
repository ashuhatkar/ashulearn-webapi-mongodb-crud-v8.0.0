using System;

namespace Nfs.Common
{
    /// <summary>
    /// Represents the base class for domain entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
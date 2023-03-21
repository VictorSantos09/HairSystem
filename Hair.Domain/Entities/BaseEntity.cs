using System;

namespace Hair.Domain.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id da entidade.
        /// </summary>
        public Guid Id { get; set; }
    }
}

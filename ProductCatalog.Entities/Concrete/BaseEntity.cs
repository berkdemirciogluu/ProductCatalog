﻿namespace ProductCatalog.Entities.Concrete
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual bool IsDeleted{ get; set; } = false;

    }
}

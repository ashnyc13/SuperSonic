using System;

namespace SuperSonic.EntityFramework.Persistence
{
    public class PersistanceActionArgs : EventArgs
    {
        public object Entity { get; set; }
        public bool CancelAction { get; set; }
    }

    public class PersistanceActionArgs<TEntity> : PersistanceActionArgs
    {
        public new TEntity Entity
        {
            get { return (TEntity)base.Entity; }
            set { base.Entity = value; }
        }
    }
}
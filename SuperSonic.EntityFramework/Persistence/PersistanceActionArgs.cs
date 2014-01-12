using System;

namespace SuperSonic.EntityFramework.Persistence
{
    public class PersistanceActionArgs : EventArgs
    {
        public object Entity { get; set; }
        public bool CancelAction { get; set; }
    }
}
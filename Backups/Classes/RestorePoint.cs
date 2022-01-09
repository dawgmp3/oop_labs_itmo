using System.Collections.Generic;

namespace Backups.Classes
{
    public class RestorePoint
    {
        public RestorePoint(List<Storage> storage)
        {
            Storages = storage;
        }

        public List<Storage> Storages { get; set; }
    }
}
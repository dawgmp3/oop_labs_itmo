using System.Collections.Generic;

namespace Backups.Classes
{
    public class RestorePoint
    {
        private List<Storage> _storage;
        public RestorePoint(List<Storage> storage)
        {
            _storage = storage;
        }

        public List<Storage> GetStorages()
        {
            return _storage;
        }
    }
}
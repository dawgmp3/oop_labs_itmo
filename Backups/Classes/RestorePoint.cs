using System;
using System.Collections.Generic;
using System.Data;

namespace Backups.Classes
{
    public class RestorePoint
    {
        private DateTime _dateTime;
        private List<Storage> _storage;
        public RestorePoint(List<Storage> storage)
        {
            Storages = storage;
        }

        public void SetDateTime()
        {
            _dateTime = DateTime.Now;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public List<Storage> GetStorages()
        {
            return _storage;
        }

        public void SetStorages(List<Storage> storages)
        {
            _storage = storages;
        }
    }
}
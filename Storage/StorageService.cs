using LunTi.Storage;
using LunTi.Models;

namespace LunTi.Storage
{
    public class StorageService
    {
        private readonly IStorage<Lab1Data> _storage;

        public StorageService(IStorage<Lab1Data> storage)
        {
            _storage = storage;
        }

        public string GetStorageType()
        {
            return _storage.StorageType;
        }

        public int GetNumberOfItems()
        {
            return _storage.All.Count;
        }
    }
} 

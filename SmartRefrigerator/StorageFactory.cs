namespace SmartRefrigerator
{
    public class StorageFactory
    {
        public IStorage GetStorage(string storageType)
        {
            switch(storageType.ToLower())
            {
                case "inmemory":
                    return new InMemoryStorage();

                case "filebased":
                    return new FileBasedStorage();
            }
            return null;
        }
    }

}

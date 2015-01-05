using System.Web.Mvc;

namespace WebShop.Utilities
{
    public interface IModelCrossRequestProvider
    {
        object Get();
        T Get<T>() where T : class;

        void Set( object model );
        void Set<T>( T model ) where T : class;
    }

    public class ModelCrossRequestProvider : IModelCrossRequestProvider
    {
        private const string ModelKey = "Model";
        private readonly TempDataDictionary _tempDataStorage;

        public ModelCrossRequestProvider(TempDataDictionary tempDataStorage)
        {
            _tempDataStorage = tempDataStorage;
        }

        public object Get()
        {
            return _tempDataStorage[ModelKey];
        }

        public T Get<T>() where T : class
        {
            return Get() as T;
        }

        public void Set(object model)
        {
            _tempDataStorage[ModelKey] = model;
        }

        public void Set<T>(T model) where T : class
        {
            Set((object)model);
        }
    }
}
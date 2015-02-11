using System.Collections.Generic;

namespace WebShop.Core.Resources
{
    public class ResourceProviderCachingDecorator : IResourceProvider
    {
        private readonly IResourceProvider _resourceProvider;
        private readonly IDictionary<string, string> _resourceDictionary = new Dictionary<string, string>();

        public ResourceProviderCachingDecorator(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }

        public string Get(string resourceName)
        {
            lock (_resourceDictionary)
            {
                string resource;
                if (!_resourceDictionary.TryGetValue(resourceName, out resource))
                {
                    resource = _resourceProvider.Get(resourceName);
                    _resourceDictionary.Add(resourceName, resource);
                }

                return resource;
            }
        }
    }
}
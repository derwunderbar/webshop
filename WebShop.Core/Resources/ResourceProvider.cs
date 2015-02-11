using System;
using System.IO;
using System.Reflection;

namespace WebShop.Core.Resources
{
    public interface IResourceProvider
    {
        string Get(string resourceName);
    }

    public class ResourceProvider : IResourceProvider
    {
        private readonly Assembly _assembly;

        public ResourceProvider()
            :this(Assembly.GetExecutingAssembly())
        {
        }

        public ResourceProvider(Assembly assembly)
        {
            _assembly = assembly;
        }

        public string Get(string resourceName)
        {
            using (var stream = _assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new InvalidOperationException(String.Format("Resource {0} not found", resourceName));

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
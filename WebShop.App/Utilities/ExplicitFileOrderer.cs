using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace WebShop.Utilities
{
    public class ExplicitFileOrderer : IBundleOrderer
    {
        public IEnumerable<FileInfo> OrderFiles( BundleContext context, IEnumerable<FileInfo> files )
        {
            return files;
        }
    }
}
using System;
using System.Diagnostics;

namespace WebShop.Services.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                if(FirstName == null)
                    throw new InvalidOperationException("Invalid FirstName");
                
                if (LastName == null)
                    throw new InvalidOperationException("Invalid LastName");

                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
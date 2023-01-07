using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biling_system_version_2_using_lists.BL
{
    class Credencials
    {
        public string name;
        public string password;
    }
    class admin_data_credentials
    {
        public string email;
        public string password;

        internal Credencials Credencials
        {
            get => default;
            set
            {
            }
        }

        internal MenuItem MenuItem
        {
            get => default;
            set
            {
            }
        }
    }
    class MenuItem
    {
        public string name;
        public string type;
        public float price;
        public MenuItem(string name,string type, float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public MenuItem() {}
    }
}


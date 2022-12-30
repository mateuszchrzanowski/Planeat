using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Role
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        protected Role()
        {
        }

        public Role(/*int id, */string name)
        {
            //Id = id;
            Name = name;
        }

        //public static Role Set(int id)
        //{
        //    if (id <= 0)
        //    {
        //        throw new Exception("Role id must be greater than 0.");
        //    }

        //    return id switch
        //    {
        //        1 => new Role(id, "User"),
        //        2 => new Role(id, "Admin"),
        //        _ => throw new Exception("Role with given id doesn't exist."),
        //    };
        //}

        //public static Role User()
        //{
        //    return new Role(1, "User");
        //}

        //public static Role Admin()
        //{
        //    return new Role(2, "Admin");
        //}
    }
}

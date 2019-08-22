using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository
    {
        public void Add(User entity)
        {
            SomethingEntitiess ctx = new SomethingEntitiess();
            ctx.User.Add(entity);
            ctx.SaveChanges();
        }
    }
}

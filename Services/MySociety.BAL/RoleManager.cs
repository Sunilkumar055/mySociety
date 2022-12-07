using MySociety.BAL.Interface;
using MySociety.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySociety.BAL
{
    class RoleManager : IRoleManager
    {

        public Task<List<Role>> Roles(int id = 0)
        {
            throw new NotImplementedException();
        }
    }
}

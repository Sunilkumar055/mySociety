using MySociety.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySociety.BAL.Interface
{
    public interface IRoleManager
    {
        Task<List<Role>> Roles(int id = 0);
    }
}

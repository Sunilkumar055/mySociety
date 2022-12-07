using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MySociety_DataAccessLayer.Interface
{
    public interface IRoleRepository
    {
        DataSet GetRole(int RoleID = 0);
    }
}

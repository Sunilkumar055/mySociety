using System;
using System.Collections.Generic;
using System.Text;

namespace MySociety.Common.Helper
{
    public static class StoreProcedures
    {
        public static string spGetUserMaster = "spGetUserMaster";
        public static string spInsertUserMaster = "spInsertUserMaster";
        public static string spAuthenticateUser = "spAuthenticateUser";
        public static string spUpdateUser = "spUpdateUser";
        public static string spDeleteUser = "spDeleteUser";

        public static string spGetRole = "spGetRole";
        public static string spAuthUser = "spAuthUser";
    }
}

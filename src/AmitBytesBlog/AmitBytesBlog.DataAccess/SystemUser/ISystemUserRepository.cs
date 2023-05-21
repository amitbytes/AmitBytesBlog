using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using BE = AmitBytesBlog.Entity;

namespace AmitBytesBlog.DataAccess
{
    public interface ISystemUserRepository : IRepository<BE.SystemUser>
    {
        BE.SystemUser AuthenticateSystemUser(string userName, string password);
        List<BE.SystemUser> GetSystemUserByQuery(BE.PageListParameters pageListParameters);
    }
}

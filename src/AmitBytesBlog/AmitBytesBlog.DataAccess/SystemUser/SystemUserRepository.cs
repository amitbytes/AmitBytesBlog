using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using BE = AmitBytesBlog.Entity;
using AmitBytesBlog.Entity.Encryption;
namespace AmitBytesBlog.DataAccess
{
    public class SystemUserRepository : Repository<BE.SystemUser>, ISystemUserRepository
    {
        //Testing Purpose Only
        public BE.SystemUser AuthenticateSystemUser(string userName, string password)
        {
            try
            {
                var filters = Builders<BE.SystemUser>.Filter.Empty;
                filters &= Builders<BE.SystemUser>.Filter.Where(u => u.UserName == userName);
                filters &= Builders<BE.SystemUser>.Filter.Where(u => u.Password == EncryptionHelper.Encrypt(password));
                return base.FindOne(filters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BE.SystemUser> GetSystemUserByQuery(BE.PageListParameters pageListParameters)
        {
            var filters = Collection.AsQueryable<BE.SystemUser>();
            return null;
        }

        #region Default Admin User Insert

        //public bool InsertDefaultSystemUser()
        //{
        //    try
        //    {
        //        var filter = Builders<BE.SystemUser>.Filter.Where(u => u.UserName == BE.Global.ADMIN_USER);
        //        var defaultUser = base.FindOne(filter);

        //        if (defaultUser != null)
        //        {
        //            defaultUser.UserName = BE.Global.ADMIN_USER;
        //            defaultUser.Password = BE.Encryption.EncryptionHelper.Encrypt(BE.Global.PASSWORD);
        //            return base.UpdateOne(c => c.UserName == BE.Global.ADMIN_USER, defaultUser);
        //        }

        //        BE.SystemUser systemUser = new BE.SystemUser()
        //        {
        //            Id = ObjectId.GenerateNewId().ToString(),
        //            FullName = "Amit Singh",
        //            UserName = BE.Global.ADMIN_USER,
        //            Password = BE.Encryption.EncryptionHelper.Encrypt(BE.Global.PASSWORD),
        //            Email = "amit.singh@amitbytes.com",
        //            MobileNo = "9825801536",
        //            Address = "Ahmedabad",
        //            IsActive = true,
        //            IsAdmin = true,
        //        };
        //        return base.UpdateOne(c => c.UserName == BE.Global.ADMIN_USER, systemUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        #endregion

    }
}

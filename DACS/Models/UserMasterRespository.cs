using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACS.Models
{
    public class UserMasterRepository : IDisposable
    {
        // SECURITY_DBEntities it is your context class
        DATHINHEntities db = new DATHINHEntities();
        //This method is used to check and validate the user credentials
        public USER ValidateUser(string username, string password)
        {
            string pw = db.proc_CryptData(password).FirstOrDefault();
            USER users = db.USERs.Where(user => user.USERNAME.Equals(username) && user.PASSWORD.Equals(pw)).FirstOrDefault();
            return users;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
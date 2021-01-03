using IQSoft.eCommerce.Entities.Security;
using System;

namespace IQSoft.eCommerce.ResourceAccess
{
    public abstract class DataAccess
    {
        protected UserContext userContext;

        protected CommonDbContext commonDbContext;
        protected ClientDbContext clientDbContext;

        private static object _syncObject = new object();

        public DataAccess(UserContext userContext = null)
        {
            this.commonDbContext = new CommonDbContext();
            if (userContext != null)
            {
                this.userContext = userContext;
                this.clientDbContext = new ClientDbContext();
            }
            else
            {
                throw new ApplicationException("Invalid user context");
            }
        }

    }
}

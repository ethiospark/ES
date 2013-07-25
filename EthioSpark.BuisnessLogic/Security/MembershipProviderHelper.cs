using System;
using System.Web.Security;
using EthioSpark.BuisnessLogic.Utils;
using EthioSpark.DataAccess.Model;
using EthioSpark.Entities;

namespace EthioSpark.BuisnessLogic.Security
{
    public static class MembershipProviderHelper
    {
        public static MembershipCreateStatus CreateUser(string username, string password, string email, ref User user)
        {
            MembershipCreateStatus status = MembershipCreateStatus.ProviderError;
            if (user != null)
            {
                MembershipCreateStatus mStatus;
                MembershipUser membershipUser = Membership.CreateUser(username, password, email, null, null, true, null, out mStatus);
                if (mStatus == MembershipCreateStatus.Success)
                {
                    try
                    {
                        using (var context = new ModelContext())
                        {
                            if (membershipUser != null && membershipUser.ProviderUserKey != null)
                            {
                                user.MembershipUserId = (int) membershipUser.ProviderUserKey;
                                //FA - TODO: Address should be properly passed in once i figure out how to handle it.
                                user.Address = new Address
                                                   {
                                                       CityCd = 2,
                                                       CountryCd = 1
                                                   };
                                context.Users.Add(user);
                                if (context.SaveChanges() > 0)
                                {
                                    status = MembershipCreateStatus.Success;
                                }
                            }
                        }
                    }
                    finally
                    {
                        try
                        {
                            if (status != MembershipCreateStatus.Success)
                            {
                                Membership.DeleteUser(username);
                            }
                        }
                        catch (Exception ex)
                        {
                            //FA - TODO: configure and use Log4NET to log exception .
                            
                        }
                    }
                }
                else
                {
                    status = mStatus;
                }
            }
            return status;
        }
    }
}

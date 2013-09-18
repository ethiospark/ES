using System;
using System.Web.Security;
using EthioSpark.Common;
using EthioSpark.DataAccess;
using EthioSpark.Entities;

namespace EthioSpark.BuisnessLogic.Security
{
    public static class MembershipProviderHelper
    {


        public static MembershipCreateStatus CreateUser(string username, string password, string email, ref User user)
        {

            MembershipCreateStatus status = MembershipCreateStatus.ProviderError;
            try
            {
                if (user != null)
                {
                    MembershipCreateStatus mStatus;
                    MembershipUser membershipUser = Membership.CreateUser(username, password, email, null, null, true,
                        null, out mStatus);
                    if (mStatus == MembershipCreateStatus.Success)
                    {
                        try
                        {
                            try
                            {
                                using (var context = new EthioSparkContext())
                                {
                                    if (membershipUser != null && membershipUser.ProviderUserKey != null)
                                    {
                                        user.MembershipUserId = (Guid)membershipUser.ProviderUserKey;
                                        //FA - TODO: Address should be properly passed in once i figure out how to handle it.
                                        Address address = new Address
                                                          {
                                                              CityCd = 2,
                                                              CountryCd = 1
                                                          };
                                        user.Address = address;
                                        context.Users.Add(user);
                                        if (context.SaveChanges() > 0)
                                        {
                                            status = MembershipCreateStatus.Success;
                                            AppLogManager.Logger.Info(string.Format("Successfuly registered user; username : '{0}'.", username));
                                        }


                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogManager.Logger.Error(
                                    string.Format(
                                        "Error creating User info in database after successfuly creating membership info; username : '{0}'",
                                        username), ex);
                                throw;
                            }
                        }
                        finally
                        {
                            try
                            {
                                if (status != MembershipCreateStatus.Success)
                                {
                                    if (!Membership.DeleteUser(username, true))
                                    {
                                        throw new Exception(
                                            string.Format("Failed to delete member ship info for username '{0}'.",
                                                username));
                                    }
                                    AppLogManager.Logger.Info(
                                        string.Format(
                                            "Membership info is has been successfuly deleted a result of a rollback action; username : '{0}'.",
                                            username));
                                }
                            }
                            catch (Exception ex)
                            {
                                AppLogManager.Logger.Error(
                                    string.Format(
                                        "Failed to remove user membership info as a result of a rollback action; username : '{0}'",
                                        username), ex);
                                throw;
                            }
                        }
                    }
                    else
                    {
                        status = mStatus;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogManager.Logger.Error(ex.Message, ex);
                throw;
            }
            return status;
        }
    }
}

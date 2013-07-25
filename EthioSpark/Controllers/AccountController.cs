using System;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using EthioSpark.Entities;
using EthioSpark.Helpers;
using EthioSpark.Models;
using EthioSpark.BuisnessLogic.Security;
namespace EthioSpark.Controllers
{

    public class AccountController : Controller
    {
        //
        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Json(new
                                {
                                    success = true
                                });
                    
                }
                ModelState.AddModelError("UserValidationError", StringResources.IncorrectUsernameOrPasswordMessage);
            }

            // If we got this far, something failed, return error messages.
            return ErrorHandler.GetModelStateErrors(ModelState);
        }

        //
        // Post: /Account/LogOff
        [HttpPost]
        public JsonResult LogOff()
        {
            FormsAuthentication.SignOut();

            return Json(new {
                success = true
            });
        }

         [AllowAnonymous]
         [HttpPost]
         public JsonResult InitRegister()
         {
             DateTime today = DateTime.Now;
             DateTime dobDefaultDate = today.AddYears(-21);
             return Json(new
                         {
                             success = true,
                             data = new
                                        {
                                            genderSetup = 0,
                                            dobDefault = new
                                                         {
                                                             day = dobDefaultDate.Day,
                                                             month = dobDefaultDate.Month,
                                                             year = dobDefaultDate.Year
                                                         },
                                            dobYearTo = today.AddYears(-18).Year,
                                            dobYearFrom = today.AddYears(-80).Year
                                        }
                         });
         }



        // POST: /Account/Register

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = model.InitUser();
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipProviderHelper.CreateUser(model.UserName, model.Password, model.Email, ref user);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);

                    return Json(new
                                {
                                    success = true
                                });
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, return error messages.
            return ErrorHandler.GetModelStateErrors(ModelState);
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}

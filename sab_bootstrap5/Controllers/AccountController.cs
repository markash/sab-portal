using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using WebMatrix.WebData;
using System.Web.Routing;

namespace Marketing.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                new UsageDataManager().TrackLoginUsage(model.UserName);

                if (!Security.HasAdministrator())
                {
                    Security.AssignRoleToUser(model.UserName, ApplicationRole.Administrator);
                }
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult MyUploads()
        {
            MyUploadsModel model = new MyUploadsModel();

            CampaignDataManager campaignManager = new CampaignDataManager();

            if (Security.CurrentUserInRole(ApplicationRole.Administrator))
            {
                model.Documents = campaignManager.RetrieveForAdmin(Security.CurrentUserName());
            }
            else
            {
                model.Documents = campaignManager.RetrieveForUser(Security.CurrentUserName());
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            Security.Logout();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

    }
}

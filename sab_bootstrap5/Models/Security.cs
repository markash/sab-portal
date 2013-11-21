using System;
using System.Web.Security;
using WebMatrix.WebData;

namespace Models
{
    public enum ApplicationRole
    {
        User,
        Administrator
    }

    public class Security
    {
        public static void Initialise()
        {
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (!Roles.RoleExists("User"))
            {
                Roles.CreateRole("User");
            }
        }

        public static bool HasAdministrator()
        {
            return Roles.GetUsersInRole(ApplicationRole.Administrator.ToString()).Length > 0;
        }

        public static bool UserExists(LoginModel model)
        {
            return WebSecurity.UserExists(model.UserName);
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public static bool Login(LoginModel model)
        {
            bool result = Membership.ValidateUser(model.UserName, model.Password);
            FormsAuthentication.SetAuthCookie(model.UserName, false);
            return result;
        }

        public static void CreateUser(LoginModel model, ApplicationRole role)
        {
            if (!WebSecurity.UserExists(model.UserName))
            {
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password, null, false);
                AssignRoleToUser(model.UserName, role);
            }
        }

        public static void CreateRoleIfNotExists(ApplicationRole role)
        {
            if (!Roles.RoleExists(role.ToString()))
            {
                Roles.CreateRole(role.ToString());
            }
        }

        public static void AssignRoleToUser(string username, ApplicationRole role)
        {
            CreateRoleIfNotExists(role);
            Roles.AddUserToRole(username, role.ToString());
        }

        public static bool CurrentUserIsAuthenticated()
        {
            return WebSecurity.IsAuthenticated;
        }

        public static bool CurrentUserInRole(ApplicationRole role)
        {
            try
            {
                return Roles.IsUserInRole(role.ToString());
            }
            catch (InvalidOperationException e)
            {
                //WebSecurity.Logout();
                return false;
            }
        }

        public static string CurrentUserName()
        {
            return WebSecurity.CurrentUserName;
        }

        public static void CreateAdministratorIfNotExisting()
        {
            if (!WebSecurity.UserExists("admin"))
            {
                CreateUser(new LoginModel { UserName = "admin", Password = "password1*", RememberMe = false }, ApplicationRole.Administrator);
            }
        }

        public static string UserEmail(string username)
        {
            return Membership.GetUser(username).Email;
        }

        public static string CurrentUserEmail()
        {
            return Membership.GetUser(WebSecurity.CurrentUserName).Email;
        }
    }
}
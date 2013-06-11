using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using DropIt.Models;
using System.Web.Security;

namespace DropIt.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<DropItContext>(null);                
                try
                {
                    using (var context = new DropItContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    if(!WebSecurity.Initialized)
                    {
                        WebSecurity.InitializeDatabaseConnection("DropItContext_User", "User", "UserId", "UserName", autoCreateTables: true);
                    }                                            
                    
                    if (!Roles.RoleExists("Administrator"))
                        Roles.CreateRole("Administrator");

                    if (!WebSecurity.UserExists("admin"))
                        WebSecurity.CreateUserAndAccount(
                            "admin",
                            "password", new { Email = "admin@gmail.com", Phone = "0909777777", Address = "123 To Ky", ProvinceId = "1", Sellable = false, Active = false, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now}, false);

                    if (!Roles.GetRolesForUser("admin").Contains("Administrator"))
                        Roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }

}

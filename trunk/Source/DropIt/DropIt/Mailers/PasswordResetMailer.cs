using Mvc.Mailer;
using DropIt.Mailers.Models;

namespace DropIt.Mailers
{ 
    public class PasswordResetMailer : MailerBase, IPasswordResetMailer 	
	{
		public PasswordResetMailer()
		{
			MasterName="_Layout";
		}

        public virtual MvcMailMessage PasswordReset(MailerModel model)
		{
            ViewBag.UserName = model.UserName;
            ViewBag.Password = model.Password;

			return Populate(x =>
			{
				x.Subject = model.Subject;
				x.ViewName = "PasswordReset";
				x.To.Add(model.ToEmail);
                x.IsBodyHtml = true;
			});
		}
 	}
}
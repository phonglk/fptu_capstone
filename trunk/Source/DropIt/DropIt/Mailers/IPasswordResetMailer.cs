using Mvc.Mailer;
using DropIt.Mailers.Models;

namespace DropIt.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}
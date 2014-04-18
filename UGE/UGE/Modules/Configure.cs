using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevMVCComponent;
using DevMVCComponent.Miscellaneous.Extensions;
using DevMVCComponent.Mailers;
using System.Reflection;
namespace Modules {
    public class Configure {


        public Configure() {
            Starter.Mailer = new GmailConfig("contact.ugeducation@gmail.com", "1234abc123");
            Config.AdminEmail = "info@developers-organism.com";
            Config.DeveloperEmail = "devorg.bd@gmail.com";
            Config.ApplicationName = "University Grade Education";
            Config.Assembly = Assembly.GetExecutingAssembly();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;

namespace Joots.Res.Api
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SetMachineKey();
        }

        private void SetMachineKey()
        {
            var mksType = typeof(MachineKeySection);
            var mksSection = ConfigurationManager.GetSection("system.web/machineKey") as MachineKeySection;
            var resetMethod = mksType.GetMethod("Reset", BindingFlags.NonPublic | BindingFlags.Instance);

            var newConfig = new MachineKeySection
            {
                ApplicationName = mksSection.ApplicationName,
                CompatibilityMode = mksSection.CompatibilityMode,
                DataProtectorType = mksSection.DataProtectorType,
                Validation = mksSection.Validation,
                ValidationKey = ConfigurationManager.AppSettings["MK_ValidationKey"],
                DecryptionKey = ConfigurationManager.AppSettings["MK_DecryptionKey"],
                Decryption = ConfigurationManager.AppSettings["MK_Decryption"],
                ValidationAlgorithm = ConfigurationManager.AppSettings["MK_ValidationAlgorithm"]
            };

            // default: AES
            // default: SHA1

            resetMethod.Invoke(mksSection, new object[] { newConfig });
        }
    }
}
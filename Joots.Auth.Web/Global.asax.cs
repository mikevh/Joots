﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Joots.Auth.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetMachineKey();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
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

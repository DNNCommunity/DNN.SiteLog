using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Dnn.Modules.SiteLog.Components;
using DotNetNuke.Common;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Instrumentation;
using DotNetNuke.Services.Installer.Log;

namespace Dnn.Modules.SiteLog.HttpModules
{
    /// <summary>
    /// Site Log Http Module.
    /// </summary>
    public class SiteLogModule : IHttpModule
    {
        private static readonly ILog Logger = LoggerSource.Instance.GetLogger(typeof(SiteLogModule));


        public int SiteLogHistory
        {
            get
            {
                var portalSettings = PortalSettings.Current;
                if (portalSettings != null)
                {
                    return PortalController.GetPortalSettingAsInteger("SiteLogHistory", portalSettings.PortalId, 0);
                }

                return 0;
            }
        }

        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += OnAuthorizeRequest;
        }

        public void Dispose()
        {
        }

        private void OnAuthorizeRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;

            //First check if we are upgrading/installing
            if (!Initialize.ProcessHttpModule(context.ApplicationInstance.Request, false, false))
            {
                return;
            }

            if (SiteLogHistory != 0)
            {
                var request = context.Request;
                //get User ID

                //affiliate processing
                var affiliateId = -1;
                if (request.QueryString["AffiliateId"] != null)
                {
                    if (Regex.IsMatch(request.QueryString["AffiliateId"], "^\\d+$"))
                    {
                        affiliateId = int.Parse(request.QueryString["AffiliateId"]);
                    }
                }

                //URL Referrer
                string urlReferrer = "";
                try
                {
                    if (request.UrlReferrer != null)
                    {
                        urlReferrer = request.UrlReferrer.ToString();
                    }
                }
                catch (Exception exc)
                {
                    Logger.Error(exc);
                }

                var siteLogStorage = "D";
                var siteLogBuffer = 1;
                var portalId = PortalSettings.Current.PortalId;

                //log visit
                var siteLogController = new SiteLogController();

                var userInfo = UserController.Instance.GetCurrentUserInfo();
                siteLogController.AddSiteLog(portalId, userInfo.UserID, urlReferrer, request.Url.ToString(),
                                       request.UserAgent, request.UserHostAddress, request.UserHostName,
                                       PortalSettings.Current.ActiveTab.TabID, affiliateId, siteLogBuffer,
                                       siteLogStorage);
            }
        }

    }
}
/*
' Copyright (c) 2016  Dan Ferguson
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using System.Web.UI.WebControls;
using DotNetNuke.Services.Localization;

namespace Dnn.Modules.SiteLog
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// In this case the settings are loaded and saved from Portal Settings
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : ModuleSettingsBase
    {
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                //set text
                lblSiteLogBufferAfter.Text = Localization.GetString("lblSiteLogBufferAfter", this.LocalResourceFile);
                lblSiteLogHistoryAfter.Text = Localization.GetString("lblSiteLogHistoryAfter", this.LocalResourceFile);

                //set radio button list
                rblSiteLogStorage.Items.Add(new ListItem(Localization.GetString("Database", this.LocalResourceFile), "D"));
                rblSiteLogStorage.Items.Add(new ListItem(Localization.GetString("FileSystem", this.LocalResourceFile), "F"));

                //load settings
                txtSiteLogBuffer.Text = PortalController.GetPortalSettingAsInteger("SiteLogBuffer", PortalSettings.PortalId, 0).ToString();
                txtSiteLogHistory.Text = PortalController.GetPortalSettingAsInteger("SiteLogHistory", PortalSettings.PortalId, 0).ToString();
                rblSiteLogStorage.SelectedValue = PortalController.GetPortalSetting("SiteLogStorage", PortalSettings.PortalId, "D");
                
            }

            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                //save settings
                PortalController.UpdatePortalSetting(PortalSettings.PortalId, "SiteLogStorage", rblSiteLogStorage.SelectedValue,PortalSettings.CultureCode);
                PortalController.UpdatePortalSetting(PortalSettings.PortalId, "SiteLogBuffer", txtSiteLogBuffer.Text, PortalSettings.CultureCode);
                PortalController.UpdatePortalSetting(PortalSettings.PortalId, "SiteLogHistory", txtSiteLogHistory.Text, PortalSettings.CultureCode);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


    }
}
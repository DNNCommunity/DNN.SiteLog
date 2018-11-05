<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Dnn.Modules.SiteLog.Settings" %>
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>
<div class="dnnForm dnnEditBasicSettings" id="dnnEditBasicSettings">
    
        
	<h2 id="dnnSitePanel-SiteLogSettings" class="dnnFormSectionHead dnnClear"><a href="" class="dnnSectionExpanded"><%=DotNetNuke.Services.Localization.Localization.GetString("SiteLogSettings")%></a></h2>
	<fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="lblSiteLogStorage" runat="server" />
            <asp:RadioButtonList ID="rblSiteLogStorage" runat="server"></asp:RadioButtonList> 
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblSiteLogBuffer" runat="server" />
            <asp:TextBox ID="txtSiteLogBuffer" runat="server" />
            <asp:Label ID="lblSiteLogBufferAfter" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblSiteLogHistory" runat="server" />
            <asp:TextBox ID="txtSiteLogHistory" runat="server" />
            <asp:Label ID="lblSiteLogHistoryAfter" runat="server" />
        </div>
    </fieldset>
 </div>

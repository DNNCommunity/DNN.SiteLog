#region Copyright
// 
// DotNetNuke® - http://www.dotnetnuke.com
// Copyright (c) 2002-2014
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion
#region Usings

using System;
using System.Data;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Entities.Content.Data;

#endregion

namespace Dnn.Modules.SiteLog.Data
{
    /// <summary>
	/// Persistent data of content with DataProvider instance.
	/// </summary>
    public class DataService : IDataService
    {
        private readonly DataProvider _provider = DataProvider.Instance();

        #region SiteLog

        public virtual void AddSiteLog(DateTime dateTime, int portalId, int userId, string referrer, string URL,
                                        string userAgent, string userHostAddress, string userHostName, int tabId,
                                        int affiliateId)
        {
            _provider.ExecuteNonQuery("AddSiteLog",
                                      dateTime,
                                      portalId,
                                      _provider.GetNull(userId),
                                      _provider.GetNull(referrer),
                                      _provider.GetNull(URL),
                                      _provider.GetNull(userAgent),
                                      _provider.GetNull(userHostAddress),
                                      _provider.GetNull(userHostName),
                                      _provider.GetNull(tabId),
                                      _provider.GetNull(affiliateId));
        }

        public virtual void DeleteSiteLog(DateTime dateTime, int portalId)
        {
            _provider.ExecuteNonQuery("DeleteSiteLog", dateTime, portalId);
        }

        public virtual IDataReader GetSiteLog(int portalId, string portalAlias, string reportName, DateTime startDate,
                                            DateTime endDate)
        {
            return _provider.ExecuteReader(reportName, portalId, portalAlias, startDate, endDate);
        }

        #endregion
    }
}
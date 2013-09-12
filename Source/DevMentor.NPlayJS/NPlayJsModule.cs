using System;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;

namespace DevMentor.NPlayJS
{
    public class NPlayJsModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            //This operation requires IIS integrated pipeline mode.
            //context.LogRequest += new EventHandler(OnLogRequest);

            context.PostMapRequestHandler += new EventHandler(ContextPostMapRequestHandler);
        }

        void ContextPostMapRequestHandler(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var page = app.Context.Handler as Page;
            if (page != null)
            {
                page.PreRender += new EventHandler(PagePreRender);
            }
        }

        void PagePreRender(object sender, EventArgs e)
        {
            var page=(Page)sender;

            if (WebConfigurationManager.AppSettings["DevMentor.NPlayJS.RequireJQuery"]!="false")
                page.Header.Controls.AddAt(page.Header.Controls.Count, new LiteralControl("<script src='"+page.ResolveUrl("~/lib/jquery/2.0.3/jquery.NPlayJS.js")+"' type='text/javascript'></script>"));
            if (WebConfigurationManager.AppSettings["DevMentor.NPlayJS.RequireAmplify"] != "false")
                page.Header.Controls.AddAt(page.Header.Controls.Count, new LiteralControl("<script src='"+page.ResolveUrl("~/lib/amplify/1.1.0/amplify.NPlayJS.js")+"' type='text/javascript'></script>"));
            page.Header.Controls.AddAt(page.Header.Controls.Count, new LiteralControl("<script src='"+page.ResolveUrl("~/App.NPlayJS.js")+"' type='text/javascript'></script>"));
            page.Header.Controls.AddAt(page.Header.Controls.Count, new LiteralControl("<link href='"+page.ResolveUrl("~/App.NPlayJS.css")+"' rel='stylesheet' type='text/css' />"));
            page.Controls.Add(new LiteralControl("<div id=\"nplayjs\"></div>"));
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }

        
    }
}

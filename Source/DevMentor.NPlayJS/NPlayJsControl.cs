using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace DevMentor.NPlayJS
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:NPlayJsControl runat=server></{0}:NPlayJsControl>")]
    public class NPlayJsControl : WebControl
    {
        readonly List<string> _files = new List<string>();
        public NPlayJsControl()
        {
            _files.Add(this.ResolveUrl("~/nplayjs/NavigateToAbout.nplay.js"));
            _files.Add(this.ResolveUrl("~/nplayjs/NavigateToLogin.nplay.js"));

        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("NPlayJS " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "<br/>");
            foreach (var f in _files)
            {
                output.Write("<a href='#' class='play'>" + f + "</a><br/>");
            }
        }
    }
}

using System;
using System.Web;
using System.Reflection;
using System.IO;
using System.Net;
using System.Web.Configuration;
using System.Web.UI;

namespace DevMentor.NPlayJS
{
    public class NPlayJsHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

            //context.Response.Write("The page request is " + context.Request.RawUrl.ToString());
            string cnt = string.Empty;
            if (context.Request.CurrentExecutionFilePathExtension == ".js")
            {
                if (context.Request.FilePath == "/App.NPlayJS.js")
                {
                    cnt = GetRessource(context.Request.FilePath);//App.NPlayJS.js
                    
                    NPlayJsControl ctrl = new NPlayJsControl();
                    var htm = RenderControlToHtml(ctrl);
                    //GetRessource("/App.NPlayJS.htm");            
                    //htm = htm.Replace("'", "''");
                    htm = htm.Replace("\"", "\\\"");
                    htm = htm.Replace("\r\n", "");
                    cnt = cnt.Replace("{0}", htm);
                    context.Response.ContentType = "application/javascript";
                    context.Response.Write(cnt);
                }
                else if (context.Request.FilePath == "/lib/jquery/2.0.3/jquery.NPlayJS.js")
                {
                    cnt = GetRessource(context.Request.FilePath);//lib.jquery._2._0._3.jquery.NPlayJS.js
                    context.Response.ContentType = "application/javascript";
                    context.Response.Write(cnt);
                }
                else if (context.Request.FilePath == "/lib/amplify/1.1.0/amplify.NPlayJS.js")
                {
                    cnt = GetRessource(context.Request.FilePath);//"lib.amplify._1._1._0.amplify.NPlayJS.js"
                    context.Response.ContentType = "application/javascript";
                    context.Response.Write(cnt);
                }
                else
                {
                    cnt = GetRessourceFile("",context.Request.FilePath);//"lib.amplify._1._1._0.amplify.NPlayJS.js"
                    context.Response.ContentType = "application/javascript";
                    context.Response.Write(cnt);
                }

            }
            else if (context.Request.CurrentExecutionFilePathExtension == ".css")
            {
                if (context.Request.FilePath == "/App.NPlayJS.css")
                {
                    cnt = GetRessource(context.Request.FilePath);//"App.NPlayJS.css"
                    context.Response.ContentType = "text/css";
                    context.Response.Write(cnt);
                }

            }
            /*
            context.Response.Write("<H1>This is an HttpHandler Test.</H1>");
            context.Response.Write("<p>Your Browser:</p>");
            context.Response.Write("Type: " + context.Request.Browser.Type + "<br>");
            context.Response.Write("Version: " + context.Request.Browser.Version);
             */
        }

        #endregion


        public string RenderControlToHtml(Control controlToRender)
        {
            var sb = new System.Text.StringBuilder();
            var stWriter = new StringWriter(sb);
            var htmlWriter = new HtmlTextWriter(stWriter);
            controlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }

        string GetRessourceFile(string path, string fileName)
        {
            string result = null;
            path = HttpContext.Current.Server.MapPath("~") + path + fileName.Replace("/", "\\");
            if (File.Exists(path))
                result = File.ReadAllText(path);

            return result;
        }

        string GetRessource(string fileName)
        {
            string result = null;
            //FileBases Development Mode
            if (WebConfigurationManager.AppSettings["DevMentor.NPlayJS.Dev.Use"] == "true")
            {
                var path = WebConfigurationManager.AppSettings["DevMentor.NPlayJS.Dev.Path"];
                result = GetRessourceFile(path, fileName);
            }
            else
            {
                //Embeded
                fileName = fileName.TrimStart('/');
                fileName = fileName.Replace("/", ".");
                fileName = fileName.Replace(".0", "._0");
                fileName = fileName.Replace(".1", "._1");
                fileName = fileName.Replace(".2", "._2");
                fileName = fileName.Replace(".3", "._3");
                fileName = fileName.Replace(".4", "._4");
                fileName = fileName.Replace(".5", "._5");
                fileName = fileName.Replace(".6", "._6");
                fileName = fileName.Replace(".7", "._7");
                fileName = fileName.Replace(".8", "._8");
                fileName = fileName.Replace(".9", "._9");

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "DevMentor.NPlayJS." + fileName;

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }

    }
}

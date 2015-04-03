using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;

namespace com.ftp.service.util
{
    public class JqHelper
    {
        /// <summary>
        /// 在页面中输出javascript脚本
        /// </summary>
        /// <param name="script">要输出的javascript脚本</param>
        public static void ResponseScript(string script)
        {
            //if (Anthem.Manager.IsCallBack)
            //{
            //    Anthem.Manager.AddScriptForClientSideEval(script);
            //}
            //else
            //{
            Page page = HttpContext.Current.Handler as Page;
            //script = String.Format(@"
            //<script type=""text/javascript"">
            //window.attachEvent(""onload"", function()
            //{{
            //{0}
            //}});
            //</script>", script);
            script = @"<script type=""text/javascript"">$(document).ready(function() {
" + script + "});</script>";
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), script, script, false);
            //}
        }
    }
}

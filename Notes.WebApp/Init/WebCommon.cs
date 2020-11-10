using Notes.Common;
using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetUsername()
        {
            if(HttpContext.Current.Session["login"] != null)
            {
                User user = HttpContext.Current.Session["login"] as User;
                return user.UserName;
            }
            return null;
        }
    }
}
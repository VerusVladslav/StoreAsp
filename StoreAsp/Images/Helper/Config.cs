using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StoreAsp.Images.Helper
{
    public static class Config
    {
        public static string NewsImagePath { get { return ConfigurationManager.AppSettings["NewsImagePath"]; } }
        public static string UserImagePath { get { return ConfigurationManager.AppSettings["UsersImagePath"]; } }

        public static string Domain { get { return ConfigurationManager.AppSettings[" DomainProject"]; } }


    }
}
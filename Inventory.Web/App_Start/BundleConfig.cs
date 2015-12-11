﻿using System.Web.Optimization;

namespace Inventory.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/extLibs").Include(
                "~/Scripts/jquery-*",
                "~/Scripts/angular.js",
                "~/Scripts/jquery.stickyheader.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Styles/normalize.css",
                "~/Styles/demo.css",
                "~/Styles/component.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
﻿using System.Web;
using System.Web.Optimization;

namespace SchoolManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Home/js/jquery.min.js",
                        "~/Content/Home/js/jquery-migrate-3.0.1.min.js",
                        "~/Content/Home/js/jquery.animateNumber.min.js",
                        "~/Content/Home/js/jquery.easing.1.3.js",
                        "~/Content/Home/js/jquery.magnific-popup.min.js",
                        "~/Content/Home/js/jquery.stellar.min.js",
                        "~/Content/Home/js/jquery.waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}

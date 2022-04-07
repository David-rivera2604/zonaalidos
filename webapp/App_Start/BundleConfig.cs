using System.Web.Optimization;

namespace aliados
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            //Base
            bundles.Add(new StyleBundle("~/Content/cssBase").Include(
                       "~/assets/bootstrap/css/bootstrap.css",
                       "~/assets/font-awesome/css/font-awesome.css",
                       "~/assets/toastr/toastr.min.css",
                       "~/assets/css/animate.css",
                       "~/assets/css/style.css",
                       "~/app/css/custom.css",
                        "~/app/css/mapfre.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsBase").Include(
                        "~/assets/jquery/jquery.js",
                        "~/assets/popper/umd/popper.js",
                        "~/assets/bootstrap/js/bootstrap.js",
                        "~/assets/js/plugins/moment/moment-with-locales.min.js",
                        "~/assets/jquery-validation/jquery.validate.js",
                        "~/assets/toastr/toastr.min.js",
                        "~/app/js/core.js",
                        "~/app/js/core.ui.js"));
            //Master
            bundles.Add(new StyleBundle("~/Content/cssMaster").Include(
                       "~/assets/bootstrap/css/bootstrap.css",
                       "~/assets/font-awesome/css/font-awesome.css",
                       "~/assets/toastr/toastr.min.css",
                       "~/assets/css/animate.css",
                        "~/assets/css/style.css",
                        "~/app/css/mapfre.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsMaster").Include(
                        "~/assets/jquery/jquery.js",
                        "~/assets/popper/umd/popper.js",
                        "~/assets/bootstrap/js/bootstrap.js",
                        "~/assets/js/plugins/moment/moment-with-locales.min.js",
                        "~/assets//jquery-validation/jquery.validate.js",
                        "~/app/js/core.js",
                        "~/app/js/core.ui.js",
                        "~/app/js/core.ui.components.js",
                        "~/assets/js/plugins/metisMenu/jquery.metisMenu.js",
                        "~/assets/js/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/assets/js/plugins/jquery-ui/jquery-ui.min.js",
                        "~/assets/js/inspinia.js",
                        "~/assets/js/plugins/pace/pace.min.js",
                        "~/assets/toastr/toastr.min.js",
                        "~/Scripts/master.js"));
            //CRUD
            bundles.Add(new StyleBundle("~/Content/cssCRUD").Include(
                       "~/assets/bootstrap-table/bootstrap-table.min.css",
                       "~/assets/css/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css",
                       "~/assets/select2/css/select2.min.css",
                       "~/assets/select2/css/select2-bootstrap4.css",
                       "~/assets/css/plugins/jQueryUI/jquery-ui.css",
                       "~/app/css/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsCRUD").Include(
                                         "~/assets/bootstrap-table/bootstrap-table.js",
                                         "~/assets/bootstrap-table/locale/bootstrap-table-es-CR.min.js",
                                         "~/assets/js/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js",
                                         "~/assets/js/plugins/jqueryformatter/jquery.formatter.js",
                                         "~/assets/js/plugins/autonumeric/autoNumeric.min.js",
                                         "~/assets/select2/js/select2.min.js"));

            //Query View
            bundles.Add(new StyleBundle("~/Content/cssView").Include(
                        "~/assets/bootstrap/css/bootstrap.css",
                       "~/assets/font-awesome/css/font-awesome.css",
                       "~/assets/toastr/toastr.min.css",
                       "~/assets/css/animate.css",
                        "~/assets/css/style.css",
                       "~/assets/bootstrap-table/bootstrap-table.min.css",
                       "~/assets/css/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css",
                       "~/assets/select2/css/select2.min.css",
                       "~/assets/select2/css/select2-bootstrap4.css",
                       "~/app/css/custom.css",
                       "~/app/css/mapfre.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsView").Include(
                                        "~/assets/jquery/jquery.js",
                                        "~/assets/popper/umd/popper.js",
                                        "~/assets/bootstrap/js/bootstrap.js",
                                        "~/assets/js/plugins/moment/moment-with-locales.min.js",
                                        "~/assets//jquery-validation/jquery.validate.js",
                                        "~/app/js/core.js",
                                        "~/app/js/core.ui.js",
                                        "~/app/js/core.ui.components.js",
                                        "~/assets/js/plugins/metisMenu/jquery.metisMenu.js",
                                        "~/assets/js/plugins/slimscroll/jquery.slimscroll.min.js",
                                        "~/assets/js/plugins/jquery-ui/jquery-ui.min.js",
                                        "~/assets/js/inspinia.js",
                                        "~/assets/js/plugins/pace/pace.min.js",
                                        "~/assets/toastr/toastr.min.js",
                                         "~/assets/tableExport.jquery.plugin/tableExport.min.js",
                                         "~/assets/bootstrap-table/bootstrap-table.js",
                                         "~/assets/bootstrap-table/locale/bootstrap-table-es-CR.min.js",
                                         "~/assets/bootstrap-table/extensions/export/bootstrap-table-export.js",
                                         "~/assets/js/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js",
                                         "~/assets/js/plugins/autonumeric/autoNumeric.min.js",
                                         "~/assets/select2/js/select2.min.js"));

            //PolicyIndex
            bundles.Add(new StyleBundle("~/Content/cssPolicyIndex").Include(
                                        "~/assets/bootstrap-table/bootstrap-table.min.css",
                                        "~/assets/select2/css/select2.min.css",
                                        "~/assets/select2/css/select2-bootstrap4.css",
                                        "~/app/css/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsPolicyIndex").Include(
                                         "~/assets/bootstrap-table/bootstrap-table.js",
                                         "~/assets/bootstrap-table/locale/bootstrap-table-es-CR.js",
                                         "~/assets/select2/js/select2.min.js",
                                         "~/Scripts/policy.common.js",
                                         "~/Scripts/policy.index.js"));
            //PolicyEdit
            bundles.Add(new StyleBundle("~/Content/cssPolicyEdit").Include(
                        "~/assets/css/plugins/footable/footable.bootstrap.min.css",
                        "~/assets/css/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css",
                       "~/app/css/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsPolicyEdit").Include(
                        "~/assets/js/plugins/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js",
                        "~/assets/js/plugins/footable/footable.min.js",
                        "~/assets/js/plugins/jqueryformatter/jquery.formatter.js",
                        "~/assets/js/plugins/autonumeric/autoNumeric.min.js",
                        "~/Scripts/policy.common.js",
                        "~/Scripts/policy.edit.asegurado.js",
                         "~/Scripts/policy.edit.cuestionario.js",
                         "~/Scripts/policy.edit.cuestionariocovid.js",
                         "~/Scripts/policy.edit.beneficiarios.js",
                         "~/Scripts/policy.edit.poliza.js",
                         "~/Scripts/policy.edit.prestamo.js",
                         "~/Scripts/policy.edit.attachment.js",
                         "~/Scripts/policy.edit.changeset.js",
                         "~/Scripts/policy.edit.js"));


            //Help
            bundles.Add(new StyleBundle("~/Content/cssHelp").Include(
                       "~/assets/bootstrap/css/bootstrap.css",
                       "~/assets/css/animate.css",
                       "~/assets/font-awesome/css/font-awesome.css",
                       "~/assets/css/style.css",
                       "~/app/css/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/jsHelp").Include(
                        "~/assets/jquery/jquery.js",
                        "~/assets/popper/umd/popper.js",
                        "~/assets/bootstrap/js/bootstrap.js",
                        "~/assets/js/plugins/metisMenu/jquery.metisMenu.js",
                        "~/assets/js/plugins/slimscroll/jquery.slimscroll.min.js",
                        "~/assets/js/plugins/pace/pace.min.js"));


            //BundleTable.EnableOptimizations = true;
        }
    }
}

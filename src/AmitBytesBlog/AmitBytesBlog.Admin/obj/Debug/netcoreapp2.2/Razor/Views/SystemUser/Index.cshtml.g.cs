#pragma checksum "D:\projects\AmitBytesBlog\src\AmitBytesBlog\AmitBytesBlog.Admin\Views\SystemUser\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2afbab496aac1e049ca74ce769ef14549b21e8d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SystemUser_Index), @"mvc.1.0.view", @"/Views/SystemUser/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SystemUser/Index.cshtml", typeof(AspNetCore.Views_SystemUser_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\projects\AmitBytesBlog\src\AmitBytesBlog\AmitBytesBlog.Admin\Views\_ViewImports.cshtml"
using AmitBytesBlog.Admin;

#line default
#line hidden
#line 2 "D:\projects\AmitBytesBlog\src\AmitBytesBlog\AmitBytesBlog.Admin\Views\_ViewImports.cshtml"
using AmitBytesBlog.Admin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2afbab496aac1e049ca74ce769ef14549b21e8d1", @"/Views/SystemUser/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65ec30320a4979433bf4b9a56b0cf8ec696ac5ff", @"/Views/_ViewImports.cshtml")]
    public class Views_SystemUser_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm btn-samesize"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "SystemUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\projects\AmitBytesBlog\src\AmitBytesBlog\AmitBytesBlog.Admin\Views\SystemUser\Index.cshtml"
  
    ViewData["Title"] = "System User";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(94, 139, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <div class=\"box box-primary\">\r\n            <div class=\"box-header with-border\">\r\n");
            EndContext();
            BeginContext(294, 103, true);
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-xs-6\">\r\n                        ");
            EndContext();
            BeginContext(397, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2afbab496aac1e049ca74ce769ef14549b21e8d14837", async() => {
                BeginContext(492, 30, true);
                WriteLiteral("<i class=\"fa fa-plus\"></i> New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(526, 1518, true);
            WriteLiteral(@"
                        <a class=""btn bg-navy btn-sm btn-samesize""><i class=""fa fa-trash""></i> Delete</a>
                        <a class=""btn bg-navy btn-sm btn-samesize""><i class=""fa fa-close""></i> Close</a>
                    </div>
                    <div class=""col-xs-6"">
                        <div class=""input-group"">
                            <span class=""input-group-addon"" style=""padding-top:2px;""><i class=""fa fa-search""></i></span>
                            <input type=""search"" class=""form-control input-sm list-search"" placeholder=""Search by UserName,Email"" />
                        </div>

                    </div>
                </div>

            </div>
            <!-- /.box-header -->
            <div class=""box-body"">
                <table id=""tblSystemUser"" class=""table table-condensed table-hover table-striped"">
                    <tbody></tbody>
                </table>
            </div>
            <!-- /.box-body -->
            <div class=""box-footer""");
            WriteLiteral(@">
                <p class=""pull-right"" id=""tblPageInfo"">
                    <small>11-20 Of 100</small>
                    <i class=""fa fa-step-backward page-icon"" id=""First""></i>
                    <i class=""fa fa-chevron-left page-icon"" id=""Prev""></i>
                    <i class=""fa fa-chevron-right page-icon"" id=""Next""></i>
                    <i class=""fa fa-step-forward page-icon"" id=""Last""></i>
                </p>
            </div>
        </div>
    </div>
</div>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2061, 3646, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        //DataGrid
        var TableGrid = (function ($) {
            var oTable;
            var InitTable = function () {
                var $table = $('#tblSystemUser');
                if ($table.length > 0) {
                    if (oTable == undefined && oTable == null) {
                        oTable = $table.DataTable({
                            ""autoWidth"": false,
                            ""paging"": true,
                            ""pagingType"": ""full"",
                            ""ordering"": true,
                            ""processing"": false,
                            ""searching"": false,
                            ""serverSide"": true,
                            ""lengthChange"": false,
                            ""info"": true,
                            ""retrieve"": true,
                            ""pageLength"": 10,
                            ""ajax"": function (data, callback, settings) {
                                settings");
                WriteLiteral(@".jqXHR = $.ajax({
                                    ""type"": ""POST"",
                                    ""url"": ""/SystemUser/GetData"",
                                    ""data"": data,
                                    ""dataType"": ""json"",
                                    ""cache"": false,
                                    ""beforeSend"": function () {

                                    },
                                    ""complete"": function () {

                                    },
                                    ""success"": function (data) {
                                        callback(data);
                                    },
                                    ""error"": function (xhr, status, error) {
                                        alert(error);
                                    }
                                });
                            },
                            ""order"": [[1, 'asc']],
                            ""columns"": [
              ");
                WriteLiteral(@"                  {
                                    ""data"": ""SystemUserId"", ""name"": ""SystemUserId"",
                                    ""render"": function (data, type, row, meta) {
                                        return '<input type=""checkbox"" value=""' + data + '"">';
                                    },
                                    ""visible"": true, ""orderable"": false, ""title"": """"
                                },
                                { ""data"": ""UserName"", ""name"": ""UserName"", ""orderable"": true, ""title"": ""Login"" },
                                { ""data"": ""FullName"", ""name"": ""FullName"", ""orderable"": true, ""title"": ""Name"" },
                                { ""data"": ""Title"", ""name"": ""Title"", ""orderable"": true, ""title"": ""Title"" },
                                { ""data"": ""Email"", ""name"": ""Email"", ""orderable"": true, ""title"": ""Email"" },
                                { ""data"": ""Mobile"", ""name"": ""Mobile"", ""orderable"": true, ""title"": ""Mobile"" },
                        ");
                WriteLiteral(@"        { ""data"": ""VersionNo"", ""name"": ""VersionNo"", ""orderable"": false, ""title"": ""VersionNo""},
                            ],
                            ""language"": {
                                ""zeroRecords"": ""No record(s) to display""
                            }
                        });
                    }
                }
            }
            return {
                BindGrid:InitTable
            };
        })(jQuery);
        //Trigger DataTable
        $(function () {
            TableGrid.BindGrid();
        });
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

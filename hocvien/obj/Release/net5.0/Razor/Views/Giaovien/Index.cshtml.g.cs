#pragma checksum "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d0119d1c7477c93a37fe4eb00772185e59d6058"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Giaovien_Index), @"mvc.1.0.view", @"/Views/Giaovien/Index.cshtml")]
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
#nullable restore
#line 1 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/_ViewImports.cshtml"
using hocvien;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/_ViewImports.cshtml"
using hocvien.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d0119d1c7477c93a37fe4eb00772185e59d6058", @"/Views/Giaovien/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5fbcff41117c351e3603dc7d0c32f3546c0ec22", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Giaovien_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<hocvien.Models.Giaovien>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "formthemGiaovien", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Index</h1>\n\n<p>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d0119d1c7477c93a37fe4eb00772185e59d60583668", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</p>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 17 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Magv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 20 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 23 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 26 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n           \n            <th>\n                ");
#nullable restore
#line 30 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 33 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 36 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Capdoday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 39 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Trinhdo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 42 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 45 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nguoitao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 48 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Ngaytao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th></th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 54 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 57 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Magv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 60 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 63 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 66 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n           \n            <td>\n                ");
#nullable restore
#line 70 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 73 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 76 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Capdoday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 79 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Trinhdo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 82 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 85 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nguoitao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 88 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ngaytao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 91 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 92 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 93 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 96 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Giaovien/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<hocvien.Models.Giaovien>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

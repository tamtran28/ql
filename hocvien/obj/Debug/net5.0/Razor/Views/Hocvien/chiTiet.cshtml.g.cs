#pragma checksum "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "609e46f0a8f15bd1ff88d9ae367315d41013a8d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hocvien_chiTiet), @"mvc.1.0.view", @"/Views/Hocvien/chiTiet.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"609e46f0a8f15bd1ff88d9ae367315d41013a8d9", @"/Views/Hocvien/chiTiet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5fbcff41117c351e3603dc7d0c32f3546c0ec22", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Hocvien_chiTiet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<hocvien.Models.CHocvienview>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
  
    ViewData["Title"] = "chiTiet";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>chiTiet</h1>\n\n<div>\n    <h4>CHocvienview</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 15 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Mahv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 18 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Mahv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 21 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 24 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 27 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 30 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 33 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 36 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 39 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 42 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 45 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 48 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 51 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Trangthai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 54 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Trangthai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
#nullable restore
#line 57 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Trungtamhoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
#nullable restore
#line 60 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Trungtamhoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 63 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Malophoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 66 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Malophoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 69 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayNameFor(model => model.Tenlop));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 72 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
       Write(Html.DisplayFor(model => model.Tenlop));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
#nullable restore
#line 77 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/Hocvien/chiTiet.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "609e46f0a8f15bd1ff88d9ae367315d41013a8d910053", async() => {
                WriteLiteral("Back to List");
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
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<hocvien.Models.CHocvienview> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
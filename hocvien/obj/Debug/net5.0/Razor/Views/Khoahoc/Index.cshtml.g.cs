#pragma checksum "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7848bd61bbd98f7d21e3500191ef17020c855136"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Khoahoc_Index), @"mvc.1.0.view", @"/Views/Khoahoc/Index.cshtml")]
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
#line 1 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\_ViewImports.cshtml"
using hocvien;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\_ViewImports.cshtml"
using hocvien.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7848bd61bbd98f7d21e3500191ef17020c855136", @"/Views/Khoahoc/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9949b033494341475e4bfe489e8b0944ed2341", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Khoahoc_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<hocvien.Model.Khoahoc>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "formthemKhoahoc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "formSuakhoahoc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "formXoakhoahoc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
  
    ViewData["Title"] = "Danh sách khóa học";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.SuccessMessage))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"msgAlert\" class=\"alert alert-success\" role=\"alert\">\r\n        ");
#nullable restore
#line 10 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
   Write(ViewBag.SuccessMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.sua))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"msgAlertS\" class=\"alert alert-success\" role=\"alert\">\r\n        ");
#nullable restore
#line 16 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
   Write(ViewBag.sua);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 18 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.xoa))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"msgAlertXoaKH\" class=\"alert alert-success\" role=\"alert\">\r\n        ");
#nullable restore
#line 22 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
   Write(ViewBag.xoa);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>Danh sách khóa học</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7848bd61bbd98f7d21e3500191ef17020c8551368008", async() => {
                WriteLiteral("Thêm khóa học");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n               Mã khóa học\r\n            </th>\r\n            <th>\r\n              Tên khóa học\r\n            </th>\r\n            <th>\r\n");
            WriteLiteral(@"            </th>
            <th>
               Mô tả
            </th>
            <th>
                Người tạo
            </th>
            <th>
               Ngày tạo
            </th>
            <th>
                Trạng thái
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 57 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Makh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Tenkh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 70 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Motakh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 73 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nguoitao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 76 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Ngaytao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 79 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Trangthai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7848bd61bbd98f7d21e3500191ef17020c85513612599", async() => {
                WriteLiteral("Sửa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
                                                     WriteLiteral(item.Makh);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7848bd61bbd98f7d21e3500191ef17020c85513614971", async() => {
                WriteLiteral("Xóa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
                                                     WriteLiteral(item.Makh);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                \r\n            </tr>\r\n");
#nullable restore
#line 89 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 93 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.SuccessMessage))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>window.onload = function () {
            var alertElement = document.getElementById('msgAlert');
            alertElement.style.display = 'block';
            setTimeout(function () {
                alertElement.style.opacity = '0';
                setTimeout(function () {
                    alertElement.style.display = 'none';
                }, 500); // Thời gian ẩn sau khi mờ dần (đơn vị: milliseconds)
            }, 2000); // Thời gian hiển thị (đơn vị: milliseconds)
        }</script>
");
#nullable restore
#line 105 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 107 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.sua))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>window.onload = function () {
            var alertElement = document.getElementById('msgAlertS');
            alertElement.style.display = 'block';
            setTimeout(function () {
                alertElement.style.opacity = '0';
                setTimeout(function () {
                    alertElement.style.display = 'none';
                }, 500); // Thời gian ẩn sau khi mờ dần (đơn vị: milliseconds)
            }, 2000); // Thời gian hiển thị (đơn vị: milliseconds)
        }</script>
");
#nullable restore
#line 119 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 121 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.xoa))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <script>
        window.onload = function () {
            var alertElement = document.getElementById('msgAlertXoaKH');
            alertElement.style.display = 'block';
            setTimeout(function () {
                alertElement.style.opacity = '0';
                setTimeout(function () {
                    alertElement.style.display = 'none';
                }, 500); // Thời gian ẩn sau khi mờ dần (đơn vị: milliseconds)
            }, 2000); // Thời gian hiển thị (đơn vị: milliseconds)
        }</script>
");
#nullable restore
#line 134 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Khoahoc\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<hocvien.Model.Khoahoc>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

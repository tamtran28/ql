#pragma checksum "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a12c746238fd626f0edd1f8d2b22f977872eeffd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Phieudangky_timLop), @"mvc.1.0.view", @"/Views/Phieudangky/timLop.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a12c746238fd626f0edd1f8d2b22f977872eeffd", @"/Views/Phieudangky/timLop.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9949b033494341475e4bfe489e8b0944ed2341", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Phieudangky_timLop : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<hocvien.Model.Loptuyensinh>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("selectCourseForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Phieudangky/SelectCourse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
  
    //Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th></th>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
           Write(Html.DisplayNameFor(model => model.Maloptuyensinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
           Write(Html.DisplayNameFor(model => model.Tenloptuyensinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
           Write(Html.DisplayNameFor(model => model.Ngaybatdau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
           Write(Html.DisplayNameFor(model => model.Ngayketthuc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
            WriteLiteral("\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n        <form method=\"post\" action=\"/Phieudangky/SelectCourse\">\r\n");
#nullable restore
#line 38 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <input type=\"checkbox\" name=\"selectedClasses\"");
            BeginWriteAttribute("value", " value=\"", 1129, "\"", 1157, 1);
#nullable restore
#line 42 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
WriteAttributeValue("", 1137, item.Maloptuyensinh, 1137, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
               Write(item.Maloptuyensinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 48 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
               Write(item.Tenloptuyensinh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 51 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
               Write(item.Ngaybatdau);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 54 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
               Write(item.Ngayketthuc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 63 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <button type=\"button\" onclick=\"submitForm()\">Lưu</button>\r\n\r\n    </table>\r\n</form>-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a12c746238fd626f0edd1f8d2b22f977872eeffd9452", async() => {
                WriteLiteral(@"
    <table class=""table"">
        <thead>
            <tr>
                <th></th>
                <th>
                   Mã lớp tuyển sinh
                </th>
                <th>
                   Tên lớp tuyển sinh
                </th>
                <th>
                   Ngày bắt đầu
                </th>
                <th>
                    Ngày kết thúc
                </th>
");
                WriteLiteral("            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 104 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        <input type=\"checkbox\" name=\"selectedClasses\"");
                BeginWriteAttribute("value", " value=\"", 3121, "\"", 3149, 1);
#nullable restore
#line 108 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
WriteAttributeValue("", 3129, item.Maloptuyensinh, 3129, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 111 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
                   Write(item.Maloptuyensinh);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 114 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
                   Write(item.Tenloptuyensinh);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 117 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
                   Write(item.Ngaybatdau);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 120 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
                   Write(item.Ngayketthuc);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n");
                WriteLiteral("                </tr>\r\n");
#nullable restore
#line 129 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Phieudangky\timLop.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n    <input type=\"submit\" value=\"Lưu\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<hocvien.Model.Loptuyensinh>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

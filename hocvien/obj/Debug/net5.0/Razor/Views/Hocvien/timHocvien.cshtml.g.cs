#pragma checksum "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebe182f11a97cfcb4c7a00430c81c2d505156673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hocvien_timHocvien), @"mvc.1.0.view", @"/Views/Hocvien/timHocvien.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebe182f11a97cfcb4c7a00430c81c2d505156673", @"/Views/Hocvien/timHocvien.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9949b033494341475e4bfe489e8b0944ed2341", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Hocvien_timHocvien : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<hocvien.Model.Hocvien>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "chiTiet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.Message))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 8 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
  Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 9 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
    
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
            WriteLiteral(@"            <th>
                Họ tên
            </th>
            <th>
               Ngày sinh
            </th>
            <th>
                SDT
            </th>
            <th>
                Địa chỉ
            </th>
            <th>
               Giới tính
            </th>
           
           
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 40 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
           Write(Html.DisplayFor(modelItem => item.Hoten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
           Write(Html.DisplayFor(modelItem => item.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
           Write(Html.DisplayFor(modelItem => item.Sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
           Write(Html.DisplayFor(modelItem => item.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n                <td>\r\n");
#nullable restore
#line 59 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
                         if (item.Gioitinh == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>Nam</span>\r\n");
#nullable restore
#line 62 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>Nữ</span>\r\n");
#nullable restore
#line 66 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n            \r\n            <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebe182f11a97cfcb4c7a00430c81c2d5051566738357", async() => {
                WriteLiteral("Chi tiết");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
                                                                      WriteLiteral(item.Mahv);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
#nullable restore
#line 76 "C:\Users\tam.tran\Downloads\trungtam-master 2 2 4 (2)\trungtam-master 2 2 4 (1)\trungtam-master 2 2 4\hocvien\Views\Hocvien\timHocvien.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<hocvien.Model.Hocvien>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/KHController1cs/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d8baf612bf41f563e43b77d315426f21acdebbf4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KHController1cs_Index), @"mvc.1.0.view", @"/Views/KHController1cs/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8baf612bf41f563e43b77d315426f21acdebbf4", @"/Views/KHController1cs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5fbcff41117c351e3603dc7d0c32f3546c0ec22", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_KHController1cs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<hocvien.Models.Khoahoc>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/KHController1cs/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Index</h1>\n");
#nullable restore
#line 8 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/KHController1cs/Index.cshtml"
 foreach (var @khoahoc in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n        <h3>Tên</h3>\n        <p>Ngày bắt đầu: ");
#nullable restore
#line 12 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/KHController1cs/Index.cshtml"
                    Write(khoahoc.Ngaytao.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        \n        <!-- Các thông tin khác của khóa học -->\n    </div>\n");
#nullable restore
#line 16 "/Users/Tracy/Downloads/trungtam-master/hocvien/Views/KHController1cs/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<hocvien.Models.Khoahoc>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

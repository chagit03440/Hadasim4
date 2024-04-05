#pragma checksum "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eafd96f757ac93faf0ebac0102ac0a9c6e60d9d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewAllEmployees), @"mvc.1.0.view", @"/Views/Home/ViewAllEmployees.cshtml")]
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
#line 1 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\_ViewImports.cshtml"
using ViewCoronaManagment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\_ViewImports.cshtml"
using ViewCoronaManagment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eafd96f757ac93faf0ebac0102ac0a9c6e60d9d1", @"/Views/Home/ViewAllEmployees.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca60eee5a38cc677d4d09c82961279a2acb92836", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewAllEmployees : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hadasim4_ex2.Models.Response>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
  
    ViewData["Title"] = "ViewAllEmployees";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
 if (Model == null || Model.ItsEmployees == null || Model.ItsEmployees.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No employees found.</p>\r\n");
#nullable restore
#line 10 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1 style=\"padding: 20px;\">List of all employees</h1>\r\n");
            WriteLiteral(@"    <div style=""overflow-x: auto;"">
        <table class=""table table-striped table-bordered"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">ID</th>
                    <th scope=""col"">First Name</th>
                    <th scope=""col"">Last Name</th>
                    <th scope=""col"">Address</th>
                    <th scope=""col"">Date of Birth</th>
                    <th scope=""col"">Telephone</th>
                    <th scope=""col"">Mobile Phone</th>
                    <th scope=""col"">Positive Result Date</th>
                    <th scope=""col"">Recovery Date</th>
                    <th scope=""col"">Employee Photo</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 32 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                 foreach (var employee in Model.ItsEmployees)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 37 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 39 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.DateOfBirth.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.Telephone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                       Write(employee.MobilePhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 42 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                        Write(employee.PositiveResultDate.HasValue ? employee.PositiveResultDate.Value.ToShortDateString() : "-");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 43 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                        Write(employee.RecoveryDate.HasValue ? employee.RecoveryDate.Value.ToShortDateString() : "-");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1871, "\"", 1896, 1);
#nullable restore
#line 45 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
WriteAttributeValue("", 1877, employee.PhotoPath, 1877, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"employee-photo\" style=\"width: 70px; height: 70px;\" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 48 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 52 "C:\Users\chagi\source\repos\Hadasim4-ex2\ViewCoronaManagment\Views\Home\ViewAllEmployees.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hadasim4_ex2.Models.Response> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "666ade3c10154040a2ded5b2372442676c31cd92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BinaryAnswer), @"mvc.1.0.view", @"/Views/BinaryAnswer.cshtml")]
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
#line 1 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\_ViewImports.cshtml"
using QuoteQuizAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\_ViewImports.cshtml"
using QuoteQuizAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"666ade3c10154040a2ded5b2372442676c31cd92", @"/Views/BinaryAnswer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68a33d6da329aedb2b13c4e423cf052baeb768fd", @"/Views/_ViewImports.cshtml")]
    public class Views_BinaryAnswer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuizModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h1 class=\"answer-binary\" >");
#nullable restore
#line 4 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
                      Write(Model.Answers.FirstOrDefault().AnswerText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n<a class=\"yes\" href=\'#\'");
            BeginWriteAttribute("onclick", " onclick=\"", 170, "\"", 267, 8);
            WriteAttributeValue("", 180, "binaryAnswer(", 180, 13, true);
#nullable restore
#line 6 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("", 193, Model.User.Id, 193, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 207, ",", 207, 1, true);
#nullable restore
#line 6 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("", 208, Model.Quote.Id, 208, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 223, ",", 223, 1, true);
#nullable restore
#line 6 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("  ", 224, Model.Answers.FirstOrDefault().Id, 226, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 260, ",", 260, 1, true);
            WriteAttributeValue(" ", 261, "true)", 262, 6, true);
            EndWriteAttribute();
            WriteLiteral(">Yes</a>\n<a class=\"no\" href=\'#\'");
            BeginWriteAttribute("onclick", " onclick=\"", 299, "\"", 397, 8);
            WriteAttributeValue("", 309, "binaryAnswer(", 309, 13, true);
#nullable restore
#line 7 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("", 322, Model.User.Id, 322, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 336, ",", 336, 1, true);
#nullable restore
#line 7 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("", 337, Model.Quote.Id, 337, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 352, ",", 352, 1, true);
#nullable restore
#line 7 "C:\Users\User\source\repos\QuoteQuizSolution\QuoteQuizAPI\Views\BinaryAnswer.cshtml"
WriteAttributeValue("  ", 353, Model.Answers.FirstOrDefault().Id, 355, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 389, ",", 389, 1, true);
            WriteAttributeValue(" ", 390, "false)", 391, 7, true);
            EndWriteAttribute();
            WriteLiteral(">No</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuizModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

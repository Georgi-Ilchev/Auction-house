#pragma checksum "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0528771a257933fbc48b918490143ebf8ac3ee0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\_ViewImports.cshtml"
using AuctionHouse.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\_ViewImports.cshtml"
using AuctionHouse.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\_ViewImports.cshtml"
using AuctionHouse.Web.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\_ViewImports.cshtml"
using AuctionHouse.Web.ViewModels.Auctions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\_ViewImports.cshtml"
using AuctionHouse.Web.ViewModels.Comments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
using AuctionHouse.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0528771a257933fbc48b918490143ebf8ac3ee0c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32595714947a82fb3c6c63fd0a82c7646bec0151", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auctions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SingleAuction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
  
    this.ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""img-fluid.max-width: 100%""
         style=""background-image: url('https://d3jlwjv6gmyigl.cloudfront.net/images/2020/10/auct.jpg'); background-repeat: repeat; "">
    <div style=""height: 36vh;""></div>
    <div class=""text-center"">
        <h1 class=""display-2 text-warning"">Welcome to ");
#nullable restore
#line 11 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                                 Write(GlobalConstants.SystemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</h1>\r\n        <div class=\"col-md-4 offset-md-4\">\r\n            <p class=\"text-warning\">This is online auction platform, which is easy to use. We have: ");
#nullable restore
#line 13 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                                                                               Write(Model.AuctionsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" auctions and ");
#nullable restore
#line 13 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                                                                                                                 Write(Model.CategoriesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" categories</p>\r\n\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("\r\n\r\n</section>\r\n<hr />\r\n<section>\r\n    <h1 class=\"display-4 text-warning\">Weekly auctions</h1>\r\n    <div class=\"col-md-12\">\r\n        <div class=\"row\">\r\n");
#nullable restore
#line 29 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
             foreach (var auction in this.Model.WeeklyAuctions)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card col-md-4 mb-4\" style=\"width: 18rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 1243, "\"", 1266, 1);
#nullable restore
#line 32 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1249, auction.ImageUrl, 1249, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1267, "\"", 1286, 1);
#nullable restore
#line 32 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1273, auction.Name, 1273, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 34 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                          Write(auction.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 35 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                        Write(auction.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0528771a257933fbc48b918490143ebf8ac3ee0c8806", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-auctionId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
                                                                                         WriteLiteral(auction.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["auctionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-auctionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["auctionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 39 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c1b7af239a1049e33f1e642e9d2862cb4b9db3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search__GridView), @"mvc.1.0.view", @"/Views/Search/_GridView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c1b7af239a1049e33f1e642e9d2862cb4b9db3a", @"/Views/Search/_GridView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32595714947a82fb3c6c63fd0a82c7646bec0151", @"/Views/_ViewImports.cshtml")]
    public class Views_Search__GridView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListAuctionsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auctions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SingleAuction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success viewBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
 if (this.Model.AuctionsCount != 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
     foreach (var auction in this.Model.Auctions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card media border-info col-md-4 mb-4 ml-4 mt-4\" style=\"width: 18rem;\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 259, "\"", 282, 1);
#nullable restore
#line 8 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
WriteAttributeValue("", 265, auction.ImageUrl, 265, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"This auction doesn`t have image\" width=\"100\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"card-title\">");
#nullable restore
#line 10 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                                  Write(auction.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p class=\"card-text\">Category: ");
#nullable restore
#line 11 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                                          Write(auction.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">\r\n");
#nullable restore
#line 13 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                     if (auction.IsActive == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-success\">Active</span>\r\n");
#nullable restore
#line 16 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"text-danger\">Inactive</span>\r\n");
#nullable restore
#line 20 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </p>\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Starting price: </span>$");
#nullable restore
#line 24 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                                                                                              Write(auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Current price: </span>$");
#nullable restore
#line 25 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                                                                                              Write(auction.BidsAmount + auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Owner: </span>");
#nullable restore
#line 26 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
                                                                                    Write(auction.UserUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n            <div class=\"card-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3c1b7af239a1049e33f1e642e9d2862cb4b9db3a9097", async() => {
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
#line 29 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
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
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 32 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td colspan=\"3\" class=\"text-center\">No results!</td>\r\n    </tr>\r\n");
#nullable restore
#line 39 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Search\_GridView.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ListAuctionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c001d0e0c112f2bfa82022c6b0b18622f90dab1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CarsListPartial), @"mvc.1.0.view", @"/Views/Shared/_CarsListPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c001d0e0c112f2bfa82022c6b0b18622f90dab1e", @"/Views/Shared/_CarsListPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32595714947a82fb3c6c63fd0a82c7646bec0151", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CarsListPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListAuctionsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SingleAuction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success viewBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"row offset-1\">\r\n");
#nullable restore
#line 4 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
     foreach (var auction in this.Model.Auctions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card media border-info col-md-4 mb-4 mr-4\" style=\"width: 18rem;\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 242, "\"", 265, 1);
#nullable restore
#line 7 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
WriteAttributeValue("", 248, auction.ImageUrl, 248, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"This auction doesn`t have image\" width=\"100\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"card-title\">");
#nullable restore
#line 9 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                  Write(auction.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p class=\"card-text\">Category: ");
#nullable restore
#line 10 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                          Write(auction.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">\r\n");
#nullable restore
#line 12 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                     if (auction.IsActive == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"h4 text-success\">Active</span>\r\n");
#nullable restore
#line 15 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"h4 text-danger\">Inactive</span>\r\n");
#nullable restore
#line 19 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </p>\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Starting price: </span>$");
#nullable restore
#line 23 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                                                                              Write(auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Current price: </span>$");
#nullable restore
#line 24 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                                                                              Write(auction.BidsAmount + auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Owner: </span>");
#nullable restore
#line 25 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                                                                    Write(auction.UserUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n            <div class=\"card-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c001d0e0c112f2bfa82022c6b0b18622f90dab1e8700", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-auctionId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
                                                       WriteLiteral(auction.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["auctionId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-auctionId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["auctionId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 31 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Shared\_CarsListPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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

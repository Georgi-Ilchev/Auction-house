#pragma checksum "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20c336650c9f5c33a6be044ef7d446993ff1b8ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auctions_AuctionByUser), @"mvc.1.0.view", @"/Views/Auctions/AuctionByUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20c336650c9f5c33a6be044ef7d446993ff1b8ff", @"/Views/Auctions/AuctionByUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32595714947a82fb3c6c63fd0a82c7646bec0151", @"/Views/_ViewImports.cshtml")]
    public class Views_Auctions_AuctionByUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ListAuctionsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SingleAuction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success viewBtn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AuctionByUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
  
    this.ViewData["Title"] = "My auctions";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-center text-monospace text-info mt-3\">");
#nullable restore
#line 7 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                 Write(this.ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 7 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                           Write(this.Model.AuctionsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<hr />\r\n\r\n");
            WriteLiteral("\r\n<br />\r\n<div class=\"row\">\r\n");
#nullable restore
#line 22 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
     foreach (var auction in this.Model.Auctions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card media col-md-4 mb-4 ml-4\" style=\"width: 18rem;\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 677, "\"", 700, 1);
#nullable restore
#line 25 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
WriteAttributeValue("", 683, auction.ImageUrl, 683, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"This auction doesn`t have image\" width=\"100\">\r\n            <div class=\"card-body\">\r\n                <h3 class=\"card-title\">");
#nullable restore
#line 27 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                  Write(auction.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <p class=\"card-text\">Category: ");
#nullable restore
#line 28 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                          Write(auction.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Starting price: </span>$");
#nullable restore
#line 31 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                              Write(auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Current price: </span>$");
#nullable restore
#line 32 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                              Write(auction.BidsAmount + auction.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Owner: </span>");
#nullable restore
#line 33 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                    Write(auction.UserUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n            <div class=\"card-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c336650c9f5c33a6be044ef7d446993ff1b8ff9311", async() => {
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
#line 36 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
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
#line 39 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<hr />\r\n\r\n<nav aria-label=\"Page navigation example\">\r\n    <ul class=\"pagination justify-content-center\">\r\n        <li");
            BeginWriteAttribute("class", " class=\"", 1725, "\"", 1797, 2);
            WriteAttributeValue("", 1733, "page-item", 1733, 9, true);
            WriteAttributeValue(" ", 1742, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 46 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                              if (!Model.HasPreviousPage) { 

#line default
#line hidden
#nullable disable
                WriteLiteral("disabled");
#nullable restore
#line 46 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                  }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 1743, 54, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c336650c9f5c33a6be044ef7d446993ff1b8ff13096", async() => {
                WriteLiteral("\r\n                <span aria-hidden=\"true\">&laquo;</span>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                              WriteLiteral(Model.PreviousPageNumber);

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
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 51 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
         for (int i = Model.PageNumber - 4; i < Model.PageNumber; i++)
        {
            if (i > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c336650c9f5c33a6be044ef7d446993ff1b8ff15865", async() => {
#nullable restore
#line 55 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                        WriteLiteral(i);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 56 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item active\" aria-current=\"page\">\r\n            <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 59 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                     Write(Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n        </li>\r\n");
#nullable restore
#line 61 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
         for (int i = Model.PageNumber + 1; i <= Model.PageNumber + 4; i++)
        {
            if (i <= Model.PagesCount)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c336650c9f5c33a6be044ef7d446993ff1b8ff19536", async() => {
#nullable restore
#line 65 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                                        WriteLiteral(i);

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
            WriteLiteral("</li>\r\n");
#nullable restore
#line 66 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li");
            BeginWriteAttribute("class", " class=\"", 2734, "\"", 2802, 2);
            WriteAttributeValue("", 2742, "page-item", 2742, 9, true);
            WriteAttributeValue(" ", 2751, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 68 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                              if (!Model.HasNextPage) { 

#line default
#line hidden
#nullable disable
                WriteLiteral("disabled");
#nullable restore
#line 68 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                                              }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 2752, 50, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20c336650c9f5c33a6be044ef7d446993ff1b8ff23421", async() => {
                WriteLiteral("\r\n                <span aria-hidden=\"true\">&raquo;</span>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\AuctionByUser.cshtml"
                                                              WriteLiteral(Model.NextPageNumber);

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
            WriteLiteral("\r\n        </li>\r\n    </ul>\r\n</nav>");
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

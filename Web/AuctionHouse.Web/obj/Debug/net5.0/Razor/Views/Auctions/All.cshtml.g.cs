#pragma checksum "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c88413d5f4e8bad3427b84d5bd53fb69c89f6df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auctions_All), @"mvc.1.0.view", @"/Views/Auctions/All.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c88413d5f4e8bad3427b84d5bd53fb69c89f6df", @"/Views/Auctions/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e874cdbd76499484eae2a1f5ede153b5080e3eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Auctions_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuctionHouse.Web.ViewModels.Auctions.ListAuctionsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
  
    this.ViewData["Title"] = "Auction list";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
Write(this.ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<hr />\r\n\r\n<div class=\"row\">\r\n");
#nullable restore
#line 10 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
     foreach(var auction in this.Model.Auctions)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card media col-md-3\" style=\"width: 18rem;\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 344, "\"", 367, 1);
#nullable restore
#line 13 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
WriteAttributeValue("", 350, auction.ImageUrl, 350, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"This auction doesn`t have image\" width=\"100\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 15 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
                                  Write(auction.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                <p class=""card-text"">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
            </div>
            <ul class=""list-group list-group-flush"">
                <li class=""list-group-item"">Cras justo odio</li>
                <li class=""list-group-item"">Dapibus ac facilisis in</li>
                <li class=""list-group-item"">Vestibulum at eros</li>
            </ul>
            <div class=""card-body"">
                <a href=""#"" class=""card-link"">Card link</a>
                <a href=""#"" class=""card-link"">Another link</a>
            </div>
        </div>
");
#nullable restore
#line 28 "C:\Users\Goshicha\Desktop\gitFolder\Auction-house\Web\AuctionHouse.Web\Views\Auctions\All.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<hr />

<nav aria-label=""Page navigation example"">
    <ul class=""pagination justify-content-center"">
        <li class=""page-item"">
            <a class=""page-link"" href=""#"" aria-label=""Previous"">
                <span aria-hidden=""true"">&laquo;</span>
            </a>
        </li>
        <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
        <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
        <li class=""page-item"">
            <a class=""page-link"" href=""#"" aria-label=""Next"">
                <span aria-hidden=""true"">&raquo;</span>
            </a>
        </li>
    </ul>
</nav>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuctionHouse.Web.ViewModels.Auctions.ListAuctionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

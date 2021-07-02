namespace AuctionHouse.Web.Areas.Administration.Controllers
{
    using AuctionHouse.Common;
    using AuctionHouse.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

using BirlesikERP.Application.Interfaces.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public async Task<IActionResult> Statistics()
        {
            var result = await _dashboardService.GetDashboardStatistic();

            return Ok(result);
        }
    }
}

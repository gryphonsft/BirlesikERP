using BirlesikERP.Application.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardStatistic();
    }
}

using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models;
using AlgoServer.Models.Algo;
using AlgoServer.Business;

namespace AlgoServer.Controllers
{
    public class AlgoController : BaseAPIController
    {
        [HttpPost("getmealplan")]
        public APIResponse<GetReportResponse> getMealPlan(GetReportRequest req)
        {

            GetReportResponse rep = new GetReportResponse
            {
                data = req.data
            };
            return APIResponse<GetReportResponse>.Ok(rep);
        }

        [HttpPost("getReport")]
        public APIResponse<GetReportResponse> getReport(GetReportRequest req)
        {
            GetReportResponse rep = AlgoBiz.CalculateReport(req);

            return APIResponse<GetReportResponse>.Ok(rep);
        }
    }
}


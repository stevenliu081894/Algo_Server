using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models;
using AlgoServer.Models.Algo;
using AlgoServer.Business;
using NuGet.Protocol.Plugins;

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
        public async Task<APIResponse<ReportModel>> getReport(ReportModel req)
        {
            try
            {
                ReportModel rep = await AlgoBiz.CalculateReport(req);

                return APIResponse<ReportModel>.Ok(rep);
            }
            catch(AppException e)
            {
                return APIResponse<ReportModel>.Error(e.GetStatus(), e.GetMessage());
            }
        }
    }
}


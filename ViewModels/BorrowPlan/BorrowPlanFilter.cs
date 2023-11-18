using AlgoServer.Internal;

namespace AlgoServer.ViewModels.BorrowPlan
{
    public class BorrowPlanFilter
    {
        /// <summary> market: 交易市场别 </summary>
        [Where("=", "market")]
        public string? market { get; set; }

    }
}

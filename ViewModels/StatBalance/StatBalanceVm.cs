using X.PagedList;

namespace AlgoServer.ViewModels.StatBalance
{
    public class StatBalanceVm
    {
        public StatBalanceSummary summary { get; set; }
        public StatBalanceFilter filter { get; set; }
        public IPagedList<StatBalanceList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.TradeMoneyCheck
{
    public class TradeMoneyCheckVm
    {
        public TradeMoneyCheckFilter filter { get; set; }
        public IPagedList<TradeMoneyCheckList> list { get; set; }
    }
}

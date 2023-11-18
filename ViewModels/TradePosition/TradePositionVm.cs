using X.PagedList;

namespace AlgoServer.ViewModels.TradePosition
{
    public class TradePositionVm
    {
        public TradePositionFilter filter { get; set; }
        public IPagedList<TradePositionList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.StockVn
{
    public class StockVnVm
    {
        public StockVnFilter filter { get; set; }
        public IPagedList<StockVnList> list { get; set; }
    }
}

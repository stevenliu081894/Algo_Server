using X.PagedList;

namespace AlgoServer.ViewModels.HisAddmoney
{
    public class HisAddmoneyVm
    {
        public HisAddmoneyFilter filter { get; set; }
        public IPagedList<HisAddmoneyList> list { get; set; }
    }
}

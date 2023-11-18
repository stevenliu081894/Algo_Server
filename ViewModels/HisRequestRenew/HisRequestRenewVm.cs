using X.PagedList;

namespace AlgoServer.ViewModels.HisRequestRenew
{
    public class HisRequestRenewVm
    {
        public HisRequestRenewFilter filter { get; set; }
        public IPagedList<HisRequestRenewList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.HisWalletRecharge
{
    public class HisWalletRechargeVm
    {
        public HisWalletRechargeFilter filter { get; set; }
        public IPagedList<HisWalletRechargeList> list { get; set; }
    }
}

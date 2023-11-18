using X.PagedList;

namespace AlgoServer.ViewModels.WalletPayment
{
    public class WalletPaymentVm
    {
        public WalletPaymentFilter filter { get; set; }
        public IPagedList<WalletPaymentList> list { get; set; }
    }
}

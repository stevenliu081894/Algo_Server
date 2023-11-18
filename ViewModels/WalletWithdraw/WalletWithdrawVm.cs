using X.PagedList;

namespace AlgoServer.ViewModels.WalletWithdraw
{
    public class WalletWithdrawVm
    {
        public WalletWithdrawFilter filter { get; set; }
        public IPagedList<WalletWithdrawList> list { get; set; }
    }
}

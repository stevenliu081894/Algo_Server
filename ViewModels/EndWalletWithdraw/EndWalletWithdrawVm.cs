using X.PagedList;

namespace AlgoServer.ViewModels.EndWalletWithdraw
{
    public class EndWalletWithdrawVm
    {
        public EndWalletWithdrawFilter filter { get; set; }
        public IPagedList<EndWalletWithdrawList> list { get; set; }
    }
}

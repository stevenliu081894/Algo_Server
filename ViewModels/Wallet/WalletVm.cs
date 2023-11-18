using X.PagedList;

namespace AlgoServer.ViewModels.Wallet
{
    public class WalletVm
    {
        public WalletFilter filter { get; set; }
        public IPagedList<WalletList> list { get; set; }
    }
}

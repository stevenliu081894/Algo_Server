using X.PagedList;

namespace AlgoServer.ViewModels.WalletTemplate
{
    public class WalletTemplateVm
    {
        public WalletTemplateFilter filter { get; set; }
        public IPagedList<WalletTemplateList> list { get; set; }
    }
}

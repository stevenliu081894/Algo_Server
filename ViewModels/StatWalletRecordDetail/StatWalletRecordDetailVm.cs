using X.PagedList;

namespace AlgoServer.ViewModels.StatWalletRecordDetail
{
    public class StatWalletRecordDetailVm
    {
        public StatWalletRecordDetailFilter filter { get; set; }
        public IPagedList<StatWalletRecordDetailList> list { get; set; }
    }
}

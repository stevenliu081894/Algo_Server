using X.PagedList;

namespace AlgoServer.ViewModels.RewardDetail
{
    public class RewardDetailVm
    {
        public RewardDetailFilter filter { get; set; }
        public IPagedList<RewardDetailList> list { get; set; }
    }
}

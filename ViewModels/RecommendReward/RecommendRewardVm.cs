using X.PagedList;

namespace AlgoServer.ViewModels.RecommendReward
{
    public class RecommendRewardVm
    {
        public RecommendRewardFilter filter { get; set; }
        public IPagedList<RecommendRewardList> list { get; set; }
    }
}

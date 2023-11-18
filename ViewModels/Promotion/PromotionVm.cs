using X.PagedList;

namespace AlgoServer.ViewModels.Promotion
{
    public class PromotionVm
    {
        public PromotionFilter filter { get; set; }
        public IPagedList<PromotionList> list { get; set; }
    }
}

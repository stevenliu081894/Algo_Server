using X.PagedList;

namespace AlgoServer.ViewModels.RecommendRegister
{
    public class RecommendRegisterVm
    {
        public RecommendRegisterFilter filter { get; set; }
        public IPagedList<RecommendRegisterList> list { get; set; }
    }
}

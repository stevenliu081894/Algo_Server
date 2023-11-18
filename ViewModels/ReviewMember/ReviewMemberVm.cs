using X.PagedList;

namespace AlgoServer.ViewModels.ReviewMember
{
    public class ReviewMemberVm
    {
        public ReviewMemberFilter filter { get; set; }
        public IPagedList<ReviewMemberList> list { get; set; }
    }
}

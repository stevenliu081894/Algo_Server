using X.PagedList;

namespace AlgoServer.ViewModels.Member
{
    public class MemberVm
    {
        public MemberFilter filter { get; set; }
        public IPagedList<MemberList> list { get; set; }
    }
}

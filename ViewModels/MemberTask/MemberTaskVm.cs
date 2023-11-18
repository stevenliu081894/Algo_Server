using X.PagedList;

namespace AlgoServer.ViewModels.MemberTask
{
    public class MemberTaskVm
    {
        public MemberTaskFilter filter { get; set; }
        public IPagedList<MemberTaskList> list { get; set; }
    }
}

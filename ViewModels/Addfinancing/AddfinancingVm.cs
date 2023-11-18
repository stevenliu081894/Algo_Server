using X.PagedList;

namespace AlgoServer.ViewModels.Addfinancing
{
    public class AddfinancingVm
    {
        public AddfinancingFilter filter { get; set; }
        public IPagedList<AddfinancingList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.HisBorrow
{
    public class HisBorrowVm
    {
        public HisBorrowFilter filter { get; set; }
        public IPagedList<HisBorrowList> list { get; set; }
    }
}

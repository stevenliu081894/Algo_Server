using X.PagedList;

namespace AlgoServer.ViewModels.ReviewBorrow
{
    public class ReviewBorrowVm
    {
        public ReviewBorrowFilter filter { get; set; }
        public IPagedList<ReviewBorrowList> list { get; set; }
    }
}

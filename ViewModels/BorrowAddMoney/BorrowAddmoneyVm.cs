using X.PagedList;

namespace AlgoServer.ViewModels.BorrowAddmoney
{
    public class BorrowAddmoneyVm
    {
        public BorrowAddmoneyFilter filter { get; set; }
        public List<BorrowAddmoneyList> list { get; set; }
    }
}

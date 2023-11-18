using X.PagedList;

namespace AlgoServer.ViewModels.AdminLog
{
    public class AdminLogVm
    {
        public AdminLogFilter filter { get; set; }
        public IPagedList<AdminLogList> list { get; set; }
    }
}

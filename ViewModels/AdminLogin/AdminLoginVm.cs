using X.PagedList;

namespace AlgoServer.ViewModels.AdminLogin
{
    public class AdminLoginVm
    {
        public AdminLoginFilter filter { get; set; }
        public IPagedList<AdminLoginList> list { get; set; }
    }
}

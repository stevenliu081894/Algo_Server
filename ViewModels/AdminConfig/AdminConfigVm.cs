using X.PagedList;

namespace AlgoServer.ViewModels.AdminConfig
{
    public class AdminConfigVm
    {
        public AdminConfigFilter filter { get; set; }
        public IPagedList<AdminConfigList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.CmsSupport
{
    public class CmsSupportVm
    {
        public CmsSupportFilter filter { get; set; }
        public IPagedList<CmsSupportList> list { get; set; }
    }
}

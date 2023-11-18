using AlgoServer.ViewModels.MultiLang;
using X.PagedList;

namespace AlgoServer.ViewModels.Bulletin
{
    public class BulletinVm
    {
        public BulletinFilter filter { get; set; }
        public IPagedList<BulletinList> list { get; set; }
    }
}

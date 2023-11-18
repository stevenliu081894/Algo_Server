using X.PagedList;

namespace AlgoServer.ViewModels.Ipwhitelist
{
    public class IpwhitelistVm
    {
        public IpwhitelistFilter filter { get; set; }
        public IPagedList<IpwhitelistList> list { get; set; }
    }
}

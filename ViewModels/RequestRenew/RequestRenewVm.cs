using X.PagedList;

namespace AlgoServer.ViewModels.RequestRenew
{
    public class RequestRenewVm
    {
        public RequestRenewFilter filter { get; set; }
        public List<RequestRenewList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.RequestStop
{
    public class RequestStopVm
    {
        public RequestStopFilter filter { get; set; }
        public List<RequestStopList> list { get; set; }
    }
}

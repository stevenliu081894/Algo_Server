using X.PagedList;

namespace AlgoServer.ViewModels.Marquee
{
    public class MarqueeVm
    {
        public MarqueeFilter filter { get; set; }
        public List<MarqueeList> list { get; set; }
    }
}

using StackExchange.Redis;
using X.PagedList;

namespace AlgoServer.ViewModels.MultiLang
{
    public class MultilangVm
    {
        public MultilangFilter filter { get; set; }
        public IPagedList<MultilangList> list { get; set; }
    }
}

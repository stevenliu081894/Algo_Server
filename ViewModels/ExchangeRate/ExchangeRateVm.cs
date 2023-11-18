using X.PagedList;

namespace AlgoServer.ViewModels.ExchangeRate
{
    public class ExchangeRateVm
    {
        public ExchangeRateFilter filter { get; set; }
        public IPagedList<ExchangeRateList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.TradingAccount
{
    public class TradingAccountVm
    {
        public TradingAccountFilter filter { get; set; }
        public List<TradingAccountList> list { get; set; }
    }
}

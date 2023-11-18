using X.PagedList;

namespace AlgoServer.ViewModels.StockHoliday
{
    public class StockHolidayVm
    {
        public StockHolidayFilter filter { get; set; }
        public IPagedList<StockHolidayList> list { get; set; }
    }
}

using X.PagedList;

namespace AlgoServer.ViewModels.SysCountry
{
    public class SysCountryVm
    {
        public SysCountryFilter filter { get; set; }
        public IPagedList<SysCountryList> list { get; set; }
    }
}

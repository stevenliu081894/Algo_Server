using X.PagedList;

namespace AlgoServer.ViewModels.UserTradeDeal
{
    public class UserTradeDealVm
    {
        public UserTradeDealFilter filter { get; set; }
        public List<UserTradeDealList> list { get; set; }
    }
}

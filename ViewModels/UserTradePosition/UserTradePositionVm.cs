using X.PagedList;

namespace AlgoServer.ViewModels.UserTradePosition
{
    public class UserTradePositionVm
    {
        public UserTradePositionFilter filter { get; set; }
        public List<UserTradePositionList> list { get; set; }
    }
}

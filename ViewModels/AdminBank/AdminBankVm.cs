using X.PagedList;

namespace AlgoServer.ViewModels.AdminBank
{
    public class AdminBankVm
    {
        public AdminBankFilter filter { get; set; }
        public List<AdminBankList> list { get; set; }
    }
}

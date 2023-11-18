using AlgoServer.ViewModels.BorrowPlan;
using AlgoServer.ViewModels.MultiLang;
using X.PagedList;

namespace AlgoServer.ViewModels.Question
{
    public class QuestionVm
    {
        public QuestionFilter filter { get; set; }
        public IPagedList<QuestionList> list { get; set; }

    }
}

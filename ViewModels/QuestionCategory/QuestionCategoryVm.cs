using AlgoServer.ViewModels.MultiLang;
using X.PagedList;

namespace AlgoServer.ViewModels.QuestionCategory
{
    public class QuestionCategoryVm
    {
        public QuestionCategoryFilter filter { get; set; }
        public IPagedList<QuestionCategoryList> list { get; set; }
    }
}

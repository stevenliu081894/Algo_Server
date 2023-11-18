using X.PagedList;

namespace AlgoServer.ViewModels.MessageTemplate
{
    public class MessageTemplateVm
    {
        public MessageTemplateFilter filter { get; set; }
        public IPagedList<MessageTemplateList> list { get; set; }
    }
}

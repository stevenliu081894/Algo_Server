using X.PagedList;

namespace AlgoServer.ViewModels.MessageRecord
{
    public class MessageRecordVm
    {
        public MessageRecordFilter filter { get; set; }
        public IPagedList<MessageRecordList> list { get; set; }
    }
}

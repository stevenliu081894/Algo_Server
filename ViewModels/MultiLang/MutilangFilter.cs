using AlgoServer.Internal;

namespace AlgoServer.ViewModels.MultiLang
{
    public class MultilangFilter
    {
        /// <summary> lang: pk </summary>
        [Where("=", "lang")]
        public string? lang { get; set; }


    }
}

using AlgoServer.Internal;

namespace AlgoServer.ViewModels.CmsSupport
{
    public class CmsSupportFilter
    {
        /// <summary> lang: 語系 </summary>
        [Where("=", "cms_support.lang")]
        public string? lang { get; set; }

    }
}

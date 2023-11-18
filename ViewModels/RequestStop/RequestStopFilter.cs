using AlgoServer.Internal;

namespace AlgoServer.ViewModels.RequestStop
{
    public class RequestStopFilter
    {
        /// <summary> sub_account: 交易帐号 </summary>
        [Where("=", "borrow_request.sub_account")]
        public string? sub_account { get; set; }

        /// <summary> member_fk: 会员FK </summary>
        [Where("=", "borrow_request.member_fk")]
        public int? member_fk { get; set; }

        /// <summary> account: 会员帐号 </summary>
        [Where("=", "vw_trade_account.account")]
        public string? account { get; set; }

        /// <summary> member_name: 会员姓名 </summary>
        [Where("LIKE", "vw_trade_account.member_name")]
        public string? member_name { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace CMSWebApi.Models
{
    public class Claim
    {
        [Key]
        public int? cId { get; set; }
        public double Amount { get; set; }
        public string ClaimDate { get; set; }
        public IList<MemberPlan>? MemberPlans { get; set; }
    }
}

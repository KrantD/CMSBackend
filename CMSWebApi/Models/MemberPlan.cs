using System.ComponentModel.DataAnnotations.Schema;

namespace CMSWebApi.Models
{
    public class MemberPlan
    {
        public int Id { get; set; }
        public int MId { get; set; }
        [ForeignKeyAttribute("MId")]
        public Member? Member { get; set; }
        public int PId { get; set; }
        [ForeignKeyAttribute("PId")]
        public Plan? Plan { get; set; }
        public int CId { get; set; }
        [ForeignKeyAttribute("CId")]
        public Claim? Claims { get; set; }
        

    }
}

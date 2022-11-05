using System.ComponentModel.DataAnnotations;

namespace CMSWebApi.Models
{
    public class Plan
    {
        [Key]
        public int pId { get; set; }
        public string? pName { get; set; }
        public string Duration { get; set; }
        public string Amount { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public IList<MemberPlan>? MemberPlans { get; set; }


    }
}

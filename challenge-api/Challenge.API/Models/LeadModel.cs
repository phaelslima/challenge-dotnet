using Challenge.API.Enums;

namespace Challenge.API.Models
{
    public class LeadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public LeadStatus Status { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

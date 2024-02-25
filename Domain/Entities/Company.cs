using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public partial class Company : BaseEntity
    {
        public required string Uid { get; set; }
        public required string Name { get; set; }
        public string? LegalSeat { get; set; }
        public string? Legalform { get; set; }
        public string? HeadOffice { get; set; }
        public DateTime? SogcDate { get; set; }
        public CompanyAdresses? Adresses { get; init; }

    }
    public partial class CompanyAdresses : BaseEntity
    {
        public required string CompanyUid { get; set; }
        public required string Adress { get; set; }

        [JsonIgnore]
        public  Company Company { get; set; }

    }



}

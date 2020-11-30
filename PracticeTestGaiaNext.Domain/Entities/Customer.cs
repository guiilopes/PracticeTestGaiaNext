using PracticeTestGaiaNext.Domain.Enums;

namespace PracticeTestGaiaNext.Domain.Entities
{
    public class Customer
    {
        public Customer(int id, string name, CompanySize companySize)
        {
            Id = id;
            Name = name;
            CompanySize = companySize;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public CompanySize CompanySize { get; set; }
    }
}

using PracticeTestGaiaNext.Api.Enums;

namespace PracticeTestGaiaNext.Api.Model
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

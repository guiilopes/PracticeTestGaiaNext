using PracticeTestGaiaNext.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PracticeTestGaiaNext.Api.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Nome deve conter entre 3 e 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Porte da empresa deve ser preenchido")]
        public CompanySize CompanySize { get; set; }
    }
}
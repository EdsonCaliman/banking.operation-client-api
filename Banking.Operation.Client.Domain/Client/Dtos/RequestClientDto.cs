using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Client.Domain.Client.Dtos
{
    public class RequestClientDto
    {
        [Required(ErrorMessage = "Name is mandatory")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddressAttribute]
        public string Email { get; set; }
    }
}

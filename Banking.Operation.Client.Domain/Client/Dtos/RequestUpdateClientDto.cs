using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Client.Domain.Client.Dtos
{
    public class RequestUpdateClientDto
    {
        [MaxLength(150)]
        public string Name { get; set; }

        [EmailAddressAttribute]
        public string Email { get; set; }
    }
}

using Banking.Operation.Client.Domain.Client.Entities;
using System;

namespace Banking.Operation.Client.Domain.Client.Dtos
{
    public class ResponseClientDto
    {
        public ResponseClientDto()
        {

        }
        public ResponseClientDto(ClientEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Email = entity.Email;
            Account = entity.Account;
            CreatedAt = entity.CreatedAt;
            CreatedBy = entity.CreatedBy;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}

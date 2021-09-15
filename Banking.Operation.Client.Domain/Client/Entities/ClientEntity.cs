using Banking.Operation.Client.Domain.Abstractions.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Banking.Operation.Client.Domain.Client.Entities
{
    public class ClientEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [EmailAddressAttribute]
        public string Email { get; set; }
        public int Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public ClientEntity(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = DateTime.Now;
            CreatedBy = CreatorHelper.GetEntityCreatorIdentity();
        }

        public void DefineRandomAcccount()
        {
            Account = new Random().Next(1000, 5000);
        }
    }
}

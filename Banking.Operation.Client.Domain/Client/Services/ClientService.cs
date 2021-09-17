using Banking.Operation.Client.Domain.Abstractions.Exceptions;
using Banking.Operation.Client.Domain.Client.Dtos;
using Banking.Operation.Client.Domain.Client.Entities;
using Banking.Operation.Client.Domain.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Client.Domain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<ResponseClientDto> GetAll()
        {
            var clientList =  _clientRepository.Get();

            return clientList.Select(c => new ResponseClientDto(c)).ToList();
        }

        public async Task<ResponseClientDto> GetOne(Guid id)
        {
            var client = await _clientRepository.FindOne(c => c.Id == id);

            return new ResponseClientDto(client);
        }

        public async Task<ResponseClientDto> Save(RequestClientDto client)
        {
            var clientEntity = new ClientEntity(Guid.NewGuid(), client.Name, client.Email);

            if (await _clientRepository.FindOne(c => c.Email == client.Email) != null)
            {
                throw new BussinessException("Operation not performed", "Email already registered");
            }

            await DefineInexistentAccountNumber(clientEntity);

            await _clientRepository.Add(clientEntity);

            var clientDto = new ResponseClientDto(clientEntity);

            return clientDto;
        }

        private async Task DefineInexistentAccountNumber(ClientEntity clientEntity)
        {
            do
            {
                clientEntity.DefineRandomAcccount();

            } while (await _clientRepository.FindOne(c => c.Account == clientEntity.Account) != null);
        }

        public async Task<ResponseClientDto> Update(Guid id, RequestClientDto client)
        {
            var clientEntity = await _clientRepository.FindOne(c => c.Id == id);

            clientEntity.Name = client.Name;
            clientEntity.Email = client.Email;

            _clientRepository.Update(clientEntity);

            return new ResponseClientDto(clientEntity);
        }

        public async Task Delete(Guid id)
        {
            var client = await _clientRepository.FindOne(c => c.Id == id);

            if (client is null)
            {
                return;
            }

            _clientRepository.Delete(client);
        }
    }
}

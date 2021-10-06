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
            var client = await GetValidClient(id);

            return new ResponseClientDto(client);
        }

        public async Task<ResponseClientDto> Save(RequestClientDto client)
        {
            var clientEntity = new ClientEntity(Guid.NewGuid(), client.Name, client.Email);

            await ValidateIfEmailAlreadyRegistered(client.Email);

            await DefineInexistentAccountNumber(clientEntity);

            await _clientRepository.Add(clientEntity);

            var clientDto = new ResponseClientDto(clientEntity);

            return clientDto;
        }

        public async Task<ResponseClientDto> Update(Guid id, RequestUpdateClientDto client)
        {
            var clientEntity = await GetValidClient(id);

            await ValidateIfEmailAlreadyRegistered(client.Email);

            if (!string.IsNullOrEmpty(client.Name))
            {
                clientEntity.Name = client.Name;
            }

            if (!string.IsNullOrEmpty(client.Email))
            {
                clientEntity.Email = client.Email;
            }

            _clientRepository.Update(clientEntity);

            return new ResponseClientDto(clientEntity);
        }

        public async Task Delete(Guid id)
        {
            var clientEntity = await GetValidClient(id);

            _clientRepository.Delete(clientEntity);
        }

        public async Task<ResponseClientDto> GetByAccount(int account)
        {
            var client = await _clientRepository.FindOne(c => c.Account == account);

            if (client is null)
            {
                return null;
            }

            return new ResponseClientDto(client);
        }

        private async Task ValidateIfEmailAlreadyRegistered(string email)
        {
            if (await _clientRepository.FindOne(c => c.Email == email) != null)
            {
                throw new BussinessException("Operation not performed", "Email already registered");
            }
        }

        private async Task DefineInexistentAccountNumber(ClientEntity clientEntity)
        {
            do
            {
                clientEntity.DefineRandomAcccount();

            } while (await _clientRepository.FindOne(c => c.Account == clientEntity.Account) != null);
        }

        private async Task<ClientEntity> GetValidClient(Guid id)
        {
            var clientEntity = await _clientRepository.FindOne(c => c.Id == id);

            if (clientEntity is null)
            {
                throw new BussinessException("Operation not performed", "Client does not registered");
            }

            return clientEntity;
        }
    }
}

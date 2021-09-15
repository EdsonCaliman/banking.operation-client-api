using Banking.Operation.Client.Domain.Client.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Banking.Operation.Client.Domain.Client.Services
{
    public interface IClientService
    {
        List<ResponseClientDto> GetAll();
        Task<ResponseClientDto> GetOne(Guid id);
        Task<ResponseClientDto> Save(RequestClientDto client);
        Task<ResponseClientDto> Update(Guid id, RequestClientDto client);
        Task Delete(Guid id);
    }
}

using Banking.Operation.Client.Domain.Client.Entities;
using Banking.Operation.Client.Domain.Client.Repositories;
using Banking.Operation.Client.Infra.Data.Repositories;

namespace Banking.Operation.Client.Infra.Data.Client.Repositories
{
    public class ClientRepository : BaseRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(AppDbContext context)
            : base(context) { }
    }
}

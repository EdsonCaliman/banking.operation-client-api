using Banking.Operation.Client.Domain.Abstractions.Exceptions;
using Banking.Operation.Client.Domain.Client.Dtos;
using Banking.Operation.Client.Domain.Client.Entities;
using Banking.Operation.Client.Domain.Client.Repositories;
using Banking.Operation.Client.Domain.Client.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banking.Operation.Client.Tests.Client.Services
{
    public class ClientServiceTest
    {
        private IClientService _clientService;
        private Mock<IClientRepository> _clientRepository;

        [SetUp]
        public void SetUp()
        {
            _clientRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_clientRepository.Object);
        }

        [Test]
        public void ShouldReturnClient()
        {
            var id = Guid.NewGuid();
            var client = new ClientEntity(id, "Test", "test");
            _clientRepository.Setup(c => c.FindOne(c => c.Id == id)).Returns(Task.FromResult(client));

            var clientSaved = _clientService.GetOne(id);

            Assert.IsNotNull(clientSaved);
        }

        [Test]
        public void ShouldReturnAllClients()
        {
            var clientList = new List<ClientEntity> {
                new ClientEntity(Guid.NewGuid(), "Test", "test"),
                new ClientEntity(Guid.NewGuid(), "Test", "test")
                }.AsQueryable();
            _clientRepository.Setup(c => c.Get()).Returns(clientList);

            var clientListSaved = _clientService.GetAll();

            Assert.IsNotNull(clientListSaved);
            Assert.AreEqual(2, clientListSaved.Count);
        }

        [Test]
        public void ShouldSaveClient()
        {
            var client = new RequestClientDto { Name = "test", Email = "test@test.com" };

            var clientSaved = _clientService.Save(client);

            Assert.IsNotNull(clientSaved);
            _clientRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ClientEntity, bool>>>()));
            _clientRepository.Verify(c => c.Add(It.IsAny<ClientEntity>()));
        }

        [Test]
        public async Task ShouldUpdateClient()
        {
            var id = Guid.NewGuid();
            var client = new RequestUpdateClientDto { Name = "test", Email = "test@test.com" };
            var clientSaved = new ClientEntity(id, "other", "other@other.com");
            _clientRepository.Setup(c => c.FindOne(c => c.Id == id)).Returns(Task.FromResult(clientSaved));

            var clientUpdated = await _clientService.Update(id, client);

            Assert.IsNotNull(clientUpdated);
            Assert.AreEqual(client.Name, clientUpdated.Name);
            Assert.AreEqual(client.Email, clientUpdated.Email);
            _clientRepository.Verify(c => c.Update(It.IsAny<ClientEntity>()));
        }

        [Test]
        public void ShouldNotUpdateClientWhenTheEmailIsAlreadyRegistered()
        {
            var id = Guid.NewGuid();
            var client = new RequestUpdateClientDto { Name = "test", Email = "test@test.com" };
            var clientSaved = new ClientEntity(id, "other", "test@test.com");
            _clientRepository.Setup(c => c.FindOne(It.IsAny<Expression<Func<ClientEntity, bool>>>())).Returns(Task.FromResult(clientSaved));

            Func<Task> action = async () => { await _clientService.Update(id, client); };
            action.Should().ThrowAsync<BussinessException>();

            _clientRepository.Verify(c => c.Update(It.IsAny<ClientEntity>()), Times.Never());
        }

        [Test]
        public void ShouldDeleteClient()
        {
            var id = Guid.NewGuid();
            var client = new ClientEntity(id, "Test", "test");
            _clientRepository.Setup(c => c.FindOne(c => c.Id == id)).Returns(Task.FromResult(client));

            _clientService.Delete(id);

            _clientRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ClientEntity, bool>>>()));
            _clientRepository.Verify(c => c.Delete(It.IsAny<ClientEntity>()));
        }

        [Test]
        public void ShouldNotDeleteInexistentClient()
        {
            var id = Guid.NewGuid();

            Func<Task> action = async () => { await _clientService.Delete(id); };
            action.Should().ThrowAsync<BussinessException>();

            _clientRepository.Verify(c => c.FindOne(It.IsAny<Expression<Func<ClientEntity, bool>>>()));
            _clientRepository.Verify(c => c.Delete(It.IsAny<ClientEntity>()), Times.Never);
        }

        [Test]
        public void ShouldReturnClientByAccount()
        {
            var id = Guid.NewGuid();
            var client = new ClientEntity(id, "Test", "test");
            _clientRepository.Setup(c => c.FindOne(c => c.Id == id)).Returns(Task.FromResult(client));

            var clientSaved = _clientService.GetByAccount(1234);

            Assert.IsNotNull(clientSaved);
        }
    }
}

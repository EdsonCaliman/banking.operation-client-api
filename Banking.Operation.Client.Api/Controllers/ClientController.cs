using Banking.Operation.Client.Domain.Client.Dtos;
using Banking.Operation.Client.Domain.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Operation.Client.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/clients")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ResponseClientDto>> GetAll()
        {
            _logger.LogInformation("Receive GetAll...");

            try
            {
                var client = _clientService.GetAll();

                if (!client.Any())
                {
                    return NoContent();
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAll exception: {ex}");
                throw;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetOne(Guid id)
        {
            _logger.LogInformation("Receive GetOne...");

            try
            {
                var client = await _clientService.GetOne(id);

                if (client is null)
                {
                    return NoContent();
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetOne exception: {ex}");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Save(RequestClientDto client)
        {
            _logger.LogInformation("Receive Save...");

            try
            {
                var clientSaved = await _clientService.Save(client);

                return Ok(clientSaved);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetOne exception: {ex}");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(Guid id, RequestClientDto client)
        {
            _logger.LogInformation("Receive Update...");

            try
            {
                var clientSaved = await _clientService.Update(id, client);

                return Ok(clientSaved);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update exception: {ex}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Receive Delete...");

            try
            {
                await _clientService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete exception: {ex}");
                return BadRequest();
            }
        }
    }
}

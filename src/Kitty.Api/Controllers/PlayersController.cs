using System;
using Kitty.Api.Infrastructure;
using Kitty.Core.Domain.Requests.Players;
using MediatR;
using Microsoft.AspNet.Mvc;

namespace Kitty.Api.Controllers
{
    [Route("/api/players")]
    public class PlayersController
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = _mediator.Send(new GetAllPlayersRequest());

            return Response.FromResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _mediator.Send(new GetPlayerDetailRequest(id));

            return Response.FromResult(result);
        }
    }
}
using System;
using Kitty.Api.Infrastructure;
using Kitty.Core.Domain.Requests.Games;
using MediatR;
using Microsoft.AspNet.Mvc;

namespace Kitty.Api.Controllers
{
    [Route("/api/games")]
    public class GamesController
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _mediator.Send(new GetAllGamesRequest());

            return Response.FromResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _mediator.Send(new GetGameDetailRequest(id));

            return Response.FromResult(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateGameRequest game)
        {
            var result = _mediator.Send(game);

            return Response.FromResult(result);
        }
    }
}
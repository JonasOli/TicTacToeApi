using System;
using AutoMapper;
using jogoVelha.Dtos;
using jogoVelha.Exceptions;
using jogoVelha.services;
using Microsoft.AspNetCore.Mvc;

namespace jogoVelha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Create()
        {
            var game = _gameService.Create();
            var gameDto = _mapper.Map<GameDto>(game);

            return Ok(gameDto);
        }

        [HttpPost("{id}/movement")]
        public ActionResult MakeAMove(string id, Movement movement)
        {
            try
            {
                if (movement.Player != "x" && movement.Player != "o")
                {
                    return BadRequest(new { msg = "Player inválido!" });
                }

                var game = _gameService.Play(id, movement.Player, movement.Position.X, movement.Position.Y);

                return Ok(new
                {
                    status = game.Status,
                    winner = game.Winner
                });
            }
            catch (MatchFinishedException ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
            catch (InvalidMatchException ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
            catch (InvalidPlayerException ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
            catch (InvalidPositionException ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = ex.Message });
            }
        }

    }
}
using System.Collections.Generic;
using GamerBacklog.Application.Interfaces;
using GamerBacklog.Domain.Entities;
using GamerBacklog.Domain.Interfaces.Services;

namespace GamerBacklog.Application
{
    public class GameAppService : AppServiceBase<Game>, IGameAppService
    {
        private readonly IGameService _gameService;

        public GameAppService(IGameService gameService) : base(gameService)
        {
            _gameService = gameService;
        }

        public IEnumerable<Game> BuscarPorNome(string nome)
        {
            return _gameService.BuscarPorNome(nome);
        }
    }
}

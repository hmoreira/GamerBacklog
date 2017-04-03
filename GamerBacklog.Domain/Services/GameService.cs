using System;
using System.Collections.Generic;
using GamerBacklog.Domain.Entities;
using GamerBacklog.Domain.Interfaces.Repositories;
using GamerBacklog.Domain.Interfaces.Services;

namespace GamerBacklog.Domain.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        private readonly IGameRepository _gameRepository; 

        public GameService(IGameRepository gameRepository) : base(gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public IEnumerable<Game> BuscarPorNome(string nome)
        {
            return _gameRepository.BuscarPorNome(nome);
        }

    }
}

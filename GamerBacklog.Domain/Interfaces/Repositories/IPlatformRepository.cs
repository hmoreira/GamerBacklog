﻿using System.Collections.Generic;
using GamerBacklog.Domain.Entities;

namespace GamerBacklog.Domain.Interfaces.Repositories
{
    public interface IPlatformRepository : IRepositoryBase<Platform>
    {
        IEnumerable<Platform> BuscarPorNome(string nome);
    }
}

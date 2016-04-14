using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Microsoft.Practices.Unity;
using DAL;
using System.Data.Entity;  

namespace GamerBacklog.Repositories
{
    public class GameRepository : IRepository<Game , int>
    {
        [Dependency]
        public GamerBacklogModel context { get; set; }

        public IEnumerable<Game> Get()
        {
            return context.Games.ToList();
        }

        public Game Get(int id)
        {
            var game = context.Games.Find(id);
            context.Entry(game).State = EntityState.Unchanged;
            return game; 
        }

        public void Add(Game entity)
        {
            context.Entry(entity).State = EntityState.Added; 
            context.Games.Add(entity);
            context.SaveChanges();
        }

        public void Remove(Game entity)
        {
            var obj = context.Games.Find(entity.Id);
            context.Entry(entity).State = EntityState.Deleted; 
            context.Games.Remove(obj);
            context.SaveChanges();
        }

        public void Update(Game entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();             
        }
       
    }
}
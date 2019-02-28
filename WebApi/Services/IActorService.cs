﻿using WebApi.Model;
using System.Collections.Generic;

namespace WebApi.Services
{
    public interface IActorService
    {
        Actor Create(Actor actor);
        Actor FindById(long id);
        List<Actor> FindByName(string name);
        List<Actor> FindAll();

        //Actor Update(Actor actor);
        //void Delete(long id);
    }
}

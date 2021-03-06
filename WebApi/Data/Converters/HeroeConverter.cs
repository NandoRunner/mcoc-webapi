﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class HeroeConverter : IParser<HeroeVO, Heroe>, IParser<Heroe, HeroeVO>
    {
        public Heroe Parse(HeroeVO origin)
        {
            if (origin == null) return new Heroe();
            return new Heroe
            {
                id = origin.Id,
                name = origin.Name,
                heroeClass = origin.heroeClass,
                releaseDate = origin.releaseDate,
                infoPage = origin.infoPage,
                stars = origin.stars
            };
        }

        public HeroeVO Parse(Heroe origin)
        {
            if (origin == null) return new HeroeVO();
            return new HeroeVO
            {
                Id = origin.id,
                Name = origin.name,
                heroeClass = origin.heroeClass,
                releaseDate = origin.releaseDate,
                infoPage = origin.infoPage,
                stars = origin.stars
            };
        }

        public List<Heroe> ParseList(List<HeroeVO> origin)
        {
            if (origin == null) return new List<Heroe>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<HeroeVO> ParseList(List<Heroe> origin)
        {
            if (origin == null) return new List<HeroeVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

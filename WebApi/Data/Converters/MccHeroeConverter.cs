using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class MccHeroeConverter : IParser<MccHeroeVO, MccHeroe>, IParser<MccHeroe, MccHeroeVO>
    {
        public MccHeroe Parse(MccHeroeVO origin)
        {
            if (origin == null) return new MccHeroe();
            return new MccHeroe
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public MccHeroeVO Parse(MccHeroe origin)
        {
            if (origin == null) return new MccHeroeVO();
            return new MccHeroeVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<MccHeroe> ParseList(List<MccHeroeVO> origin)
        {
            if (origin == null) return new List<MccHeroe>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MccHeroeVO> ParseList(List<MccHeroe> origin)
        {
            if (origin == null) return new List<MccHeroeVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class AbilityConverter : IParser<AbilityVO, Ability>, IParser<Ability, AbilityVO>
    {
        public Ability Parse(AbilityVO origin)
        {
            if (origin == null) return new Ability();
            return new Ability
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public AbilityVO Parse(Ability origin)
        {
            if (origin == null) return new AbilityVO();
            return new AbilityVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<Ability> ParseList(List<AbilityVO> origin)
        {
            if (origin == null) return new List<Ability>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AbilityVO> ParseList(List<Ability> origin)
        {
            if (origin == null) return new List<AbilityVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

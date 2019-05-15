using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class MccAbilityConverter : IParser<MccAbilityVO, MccAbility>, IParser<MccAbility, MccAbilityVO>
    {
        public MccAbility Parse(MccAbilityVO origin)
        {
            if (origin == null) return new MccAbility();
            return new MccAbility
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public MccAbilityVO Parse(MccAbility origin)
        {
            if (origin == null) return new MccAbilityVO();
            return new MccAbilityVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<MccAbility> ParseList(List<MccAbilityVO> origin)
        {
            if (origin == null) return new List<MccAbility>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MccAbilityVO> ParseList(List<MccAbility> origin)
        {
            if (origin == null) return new List<MccAbilityVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

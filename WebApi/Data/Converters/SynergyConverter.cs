using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class SynergyConverter : IParser<SynergyVO, Synergy>, IParser<Synergy, SynergyVO>
    {
        public Synergy Parse(SynergyVO origin)
        {
            if (origin == null) return new Synergy();
            return new Synergy
            {
                id = origin.Id,
                name = origin.Name

    };
        }

        public SynergyVO Parse(Synergy origin)
        {
            if (origin == null) return new SynergyVO();
            return new SynergyVO
            {
                Id = origin.id,
                Name = origin.name
    };
        }

        public List<Synergy> ParseList(List<SynergyVO> origin)
        {
            if (origin == null) return new List<Synergy>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<SynergyVO> ParseList(List<Synergy> origin)
        {
            if (origin == null) return new List<SynergyVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

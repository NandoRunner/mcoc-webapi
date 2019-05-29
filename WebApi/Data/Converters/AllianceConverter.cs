using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class AllianceConverter : IParser<AllianceVO, Alliance>, IParser<Alliance, AllianceVO>
    {
        public Alliance Parse(AllianceVO origin)
        {
            if (origin == null) return new Alliance();
            return new Alliance
            {
                id = origin.Id,
                name = origin.Name
    };
        }

        public AllianceVO Parse(Alliance origin)
        {
            if (origin == null) return new AllianceVO();
            return new AllianceVO
            {
                Id = origin.id,
                Name = origin.name
    };
        }

        public List<Alliance> ParseList(List<AllianceVO> origin)
        {
            if (origin == null) return new List<Alliance>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AllianceVO> ParseList(List<Alliance> origin)
        {
            if (origin == null) return new List<AllianceVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

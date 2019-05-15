using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class MccHashtagConverter : IParser<MccHashtagVO, MccHashtag>, IParser<MccHashtag, MccHashtagVO>
    {
        public MccHashtag Parse(MccHashtagVO origin)
        {
            if (origin == null) return new MccHashtag();
            return new MccHashtag
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public MccHashtagVO Parse(MccHashtag origin)
        {
            if (origin == null) return new MccHashtagVO();
            return new MccHashtagVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<MccHashtag> ParseList(List<MccHashtagVO> origin)
        {
            if (origin == null) return new List<MccHashtag>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<MccHashtagVO> ParseList(List<MccHashtag> origin)
        {
            if (origin == null) return new List<MccHashtagVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

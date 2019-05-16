using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class HashtagConverter : IParser<HashtagVO, Hashtag>, IParser<Hashtag, HashtagVO>
    {
        public Hashtag Parse(HashtagVO origin)
        {
            if (origin == null) return new Hashtag();
            return new Hashtag
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public HashtagVO Parse(Hashtag origin)
        {
            if (origin == null) return new HashtagVO();
            return new HashtagVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<Hashtag> ParseList(List<HashtagVO> origin)
        {
            if (origin == null) return new List<Hashtag>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<HashtagVO> ParseList(List<Hashtag> origin)
        {
            if (origin == null) return new List<HashtagVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Converter;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class GenreConverter : IParser<GenreVO, Genre>, IParser<Genre, GenreVO>
    {
        public Genre Parse(GenreVO origin)
        {
            if (origin == null) return new Genre();
            return new Genre
            {
                id = origin.Id,
                name = origin.Name
            };
        }

        public GenreVO Parse(Genre origin)
        {
            if (origin == null) return new GenreVO();
            return new GenreVO
            {
                Id = origin.id,
                Name = origin.name
            };
        }

        public List<Genre> ParseList(List<GenreVO> origin)
        {
            if (origin == null) return new List<Genre>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<GenreVO> ParseList(List<Genre> origin)
        {
            if (origin == null) return new List<GenreVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

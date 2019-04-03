using System.Collections.Generic;
using WebApi.Data.VO;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IGenreBusiness
    {
        GenreVO Create(GenreVO genre);
        GenreVO FindById(long id);
        List<GenreVO> FindByName(string name);
        List<GenreVO> FindAll();

        GenreVO Update(GenreVO genre);
        void Delete(long id);

        List<_vw_mc_genero> FindMovieCount(enMovieCount order);
    }
}

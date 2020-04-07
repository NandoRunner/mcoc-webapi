using System.Collections.Generic;

using WebApi.Model;
using WebApi.Model.Integrations;

namespace WebApi.Business
{
    public interface IFileRenamerBusiness
    {
        FileRenamer Create(FileRenamer item);
        List<FileRenamer> FindAll();

        List<FileRenamerRequest> FindAllRequest();

        void Delete(long id);
    }
}

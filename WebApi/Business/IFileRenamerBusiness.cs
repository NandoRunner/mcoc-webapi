using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Business
{
    public interface IFileRenamerBusiness
    {
        FileRenamer Create(FileRenamer item);
        List<FileRenamer> FindAll();
    }
}

using System.Collections.Generic;
using WebApi.Model;
using System.Threading;
using WebApi.Model.Context;
using System;
using System.Linq;
using WebApi.Repository;
using WebApi.Repository.Generic;
using WebApi.Data.Converters;
using WebApi.Data.VO;
using WebApi.Integrations.Model;

namespace WebApi.Business.Implementattions
{
    public class FileRenamerBusinessImpl : IFileRenamerBusiness
    {
        private readonly IRepositoryId<FileRenamer> _repository;

        private readonly FileRenamerConverter _converter;

        public FileRenamerBusinessImpl(IRepositoryId<FileRenamer> repository)
        {
            _repository = repository;
            _converter = new FileRenamerConverter();
        }

        public FileRenamer Create(FileRenamer item)
        {
            return _repository.Create(item);
         }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<FileRenamer> FindAll()
        {
            return _repository.FindAll();
        }

        public List<FileRenamerRequest> FindAllRequest()
        {
            return _converter.ParseList(_repository.FindAll());
        }

    }
}

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

namespace WebApi.Business.Implementattions
{
    public class FileRenamerBusinessImpl : IFileRenamerBusiness
    {
        private readonly IRepositoryId<FileRenamer> _repository;

        public FileRenamerBusinessImpl(IRepositoryId<FileRenamer> repository)
        {
            _repository = repository;
        }

        public FileRenamer Create(FileRenamer item)
        {
            return _repository.Create(item);
         }

        public List<FileRenamer> FindAll()
        {
            return _repository.FindAll();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Converter;
using WebApi.Integrations.Model;
using WebApi.Model;

namespace WebApi.Data.Converters
{
    public class FileRenamerConverter : IParser<FileRenamerRequest, FileRenamer>, IParser<FileRenamer, FileRenamerRequest>
    {
        public FileRenamer Parse(FileRenamerRequest origin)
        {
            if (origin == null) return new FileRenamer();
            return new FileRenamer
            {
                caminho = origin.caminho,
                extensao = origin.extensao,
                prefixo = origin.prefixo,
                substituir = origin.substituir,
                substpor = origin.substpor,
                abreviar = origin.abreviar
            };
        }

        public FileRenamerRequest Parse(FileRenamer origin)
        {
            if (origin == null) return new FileRenamerRequest();
            return new FileRenamerRequest
            {
                caminho = origin.caminho,
                extensao = origin.extensao,
                prefixo = origin.prefixo,
                substituir = origin.substituir,
                substpor = origin.substpor,
                abreviar = origin.abreviar
            };
        }

        public List<FileRenamer> ParseList(List<FileRenamerRequest> origin)
        {
            if (origin == null) return new List<FileRenamer>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<FileRenamerRequest> ParseList(List<FileRenamer> origin)
        {
            if (origin == null) return new List<FileRenamerRequest>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

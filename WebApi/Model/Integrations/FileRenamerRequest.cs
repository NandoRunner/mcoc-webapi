using System;

namespace WebApi.Model.Integrations
{ 
    public class FileRenamerRequest 
    {
        public string caminho { get; set; }

        public string extensao { get; set; }

        public string prefixo { get; set; }

        public string substituir { get; set; }

        public string substpor { get; set; }

        public string abreviar { get; set; }

        public long? id { get; set; }
    }
}

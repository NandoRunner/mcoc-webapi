using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WebApi.Model.Base;

namespace WebApi.Model
{
    [Table("file_renamer_command")]
    public class FileRenamer : BaseIdEntity
    {
        [DataMember(Order = 2)]
        public string caminho { get; set; }

        [DataMember(Order = 3)]
        public string extensao { get; set; }

        [DataMember(Order = 4)]
        public string prefixo { get; set; }

        [DataMember(Order = 5)]
        public string substituir { get; set; }

        [DataMember(Order = 6)]
        public string substpor { get; set; }

        [DataMember(Order = 7)]
        public string abreviar { get; set; }
    }
}

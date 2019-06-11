using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("web_users")]
    public class WebUser
    {
        public long? Id { get; set; }
        public string Login { get; set; }
        public string AccessKey { get; set; }
    }
}

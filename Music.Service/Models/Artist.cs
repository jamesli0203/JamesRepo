using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Models
{
    [Table("Artist", Schema = "dbo")]
    public class Artist : BaseModel
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Models
{
    [Table("Song", Schema = "dbo")]
    public class Song : BaseModel
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int Track { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Album Album { get; set; }
        [ForeignKey("Album")]
        public long AlbumId { get; set; }
    }
}

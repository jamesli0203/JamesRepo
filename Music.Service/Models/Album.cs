using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Models
{
    [Table("Album", Schema = "dbo")]
    public class Album : BaseModel
    {
        [Key]
        public long Id { get ; set ; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get ; set ; }
        public int YearReleases { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Artist Artist { get; set; }
        [ForeignKey("Artist")]
        public long ArtistId { get; set; }
        public List<Song> Songs { get; set; }
    }
}

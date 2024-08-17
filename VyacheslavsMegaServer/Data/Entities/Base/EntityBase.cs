using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VyacheslavsMegaServer.Data.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}

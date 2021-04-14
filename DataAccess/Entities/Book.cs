using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public partial class Book
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int VisitorId { get; set; }
        public string Name { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}

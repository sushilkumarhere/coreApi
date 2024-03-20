using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exceltosql.Models
{
    public partial class emp:baseClass
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute makes the Id property auto-increment
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool Gender { get; set; }

    } 


}

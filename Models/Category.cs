using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerLearning.Models
{
    public class Category
    {
        [Key] //primary key
        public int CategoryId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage ="Title is required")]
        public String Title { get; set; } //greenline=> notnullable property
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";

        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";

        [NotMapped]
        public String? TitleWithIcon {
            get
            {
                return this.Icon+" "+ this.Title;
            }
        
        
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTrackerLearning.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Please Enter a Category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } //navigation property for foreign key

        [Range(1,int.MaxValue,ErrorMessage ="Amount should be greater than 0.")]
        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public String? Note { get; set; } //? this means nullable string

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public String CategoryTitleWithIcon { get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        [NotMapped]
        public String FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type=="Expense") ? "-" : "+")+ Amount.ToString("C0");
            }
        }
    }
}

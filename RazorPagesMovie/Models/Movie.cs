using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        
        [Display(Name = "Release Date")]//[Display] 属性指定字段的显示名称
        [DataType(DataType.Date)]//[DataType] 属性，用于指定 ReleaseDate 属性中的数据类型。 通过此特性：用户无需在日期字段中输入时间信息。仅显示日期，而非时间信息。
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }
        public string Rating { get; set; } = string.Empty;
    }
}

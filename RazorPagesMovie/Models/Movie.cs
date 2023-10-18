using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        //[DataType] 属性，用于指定 ReleaseDate 属性中的数据类型。 通过此特性：
        //用户无需在日期字段中输入时间信息。
        //仅显示日期，而非时间信息。
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}

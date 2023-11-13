using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract record BookDtoForManipulation
    {
        [Required(ErrorMessage = "Title is a required field")]
        [MinLength(2,ErrorMessage = "Ttile must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Ttile must consist of at maximum 2 characters")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Price is a required field")]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}

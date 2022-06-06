using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Entities.Dtos
{
    public class CompanyUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Şirket İsmi")]
        [Required(ErrorMessage = "Şirket İsmi Boş Geçilmemeli.")]
        [MaxLength(100, ErrorMessage = "Şirket İsmi 100 karakterden fazla olamaz.")]
        public string Name { get; set; }
    }
}

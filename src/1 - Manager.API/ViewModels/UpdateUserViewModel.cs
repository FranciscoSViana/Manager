using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "O id n�o pode ser vazio")]
        [Range(1, int.MaxValue, ErrorMessage = "O id n�o pode ser menor que 1")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome n�o pode ser nulo")]
        [MinLength(3, ErrorMessage = "O nome deve ter no m�nimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no m�ximo 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail n�o pode ser nulo")]
        [MinLength(10, ErrorMessage = "O e-mail deve ter no m�nimo 10 caracteres")]
        [MaxLength(180, ErrorMessage = "O e-mail deve ter no m�ximo 180 caracteres")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "O e-mail informado n�o � v�lido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha n�o pode ser nula")]
        [MinLength(6, ErrorMessage = "A senha deve ter no m�nimo 6 caracteres")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no m�ximo 80 caracteres")]
        public string Password { get; set; }
    }
}
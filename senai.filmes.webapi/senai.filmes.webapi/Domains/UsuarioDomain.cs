using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.filmes.webapi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength (20, MinimumLength = 3, ErrorMessage = "A senha precisa ter entre 3 e 20 caracteres!")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECO_P2_2
{
    internal class SessaoUsuario
    {
        public static int Id { get; set; }
        public static string NomeCompleto { get; set; }
        public static string NumeroBI { get; set; }
        public static string Periodo { get; set; }
        public static string Senha { get; set; }
        public static string Estado { get; set; }
        public static bool IsFuncionario { get; set; }


        public static void limpar()
        {
            Id = 0;
            NomeCompleto = null;
            NumeroBI = null;
            Periodo = null;
            Senha = null;
            Estado = null;
            IsFuncionario = false;
        }
    }
}

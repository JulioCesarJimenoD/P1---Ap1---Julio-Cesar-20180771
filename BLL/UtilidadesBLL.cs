using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1___Ap1___Julio_Cesar_20180771.BLL
{
    public class UtilidadesBLL
    {
        public static int ToInt(String valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
        }
    }
}

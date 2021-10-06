﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1___Ap1___Julio_Cesar_20180771.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteID { get; set; }
        public string Persona { get; set; }
        public string  Concepto { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}

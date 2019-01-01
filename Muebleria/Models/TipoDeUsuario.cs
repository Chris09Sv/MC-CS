using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Muebleria.Models
{
    public class TipoDeUsuario
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
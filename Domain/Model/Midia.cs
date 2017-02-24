using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Midia
    {
        public int ID { get; private set; }
        public byte[] Arquivo { get; private set; }
        public string Extensao { get; private set; }
        public ETipoMidia Tipo { get; private set; }

        protected Midia()
        {

        }
    }
}

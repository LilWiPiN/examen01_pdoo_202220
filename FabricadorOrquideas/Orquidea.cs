using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricadorOrquideas
{
    public abstract class Orquidea
    {
        protected string region, periodoFloracion, uso;

        public Orquidea()
        {
            region = "";
            periodoFloracion = "";
            uso = "";
        }

        public Orquidea(string region, string periodoFloracion, string uso)
        {
            this.region = region;
            this.periodoFloracion = periodoFloracion;
            this.uso = uso;
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public string PeriodoFloracion
        {
            get { return periodoFloracion; }
            set { periodoFloracion = value; }
        }

        public string Uso
        {
            get { return uso; }
            set { uso = value; }
        }

        public abstract string InformacionOrquidea();
    }
}

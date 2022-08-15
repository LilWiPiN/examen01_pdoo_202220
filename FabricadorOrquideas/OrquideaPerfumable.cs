using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricadorOrquideas
{
    public class OrquideaPerfumable : Orquidea, IPerfumable
    {
        public OrquideaPerfumable() : base()
        {
        }

        public OrquideaPerfumable(string region, string periodoFloracion, string uso) : base(region, periodoFloracion, uso)
        {
            this.region = region;
            this.periodoFloracion = periodoFloracion;
            this.uso = uso;
        }

        public string InfoPerfumable()
        {
            string info = $"Uso: {uso}";
            return info;
        }

        public override string InformacionOrquidea()
        {
            string info = $"Esta orquidea proviene de la region: {region}.\nPeriodo de floracion {periodoFloracion}.";

            InfoPerfumable();
            return info;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricadorOrquideas
{
    public class OrquideaAmbas : Orquidea, IAmbas
    {
        public OrquideaAmbas() : base()
        {
        }

        public OrquideaAmbas(string region, string periodoFloracion, string uso) : base(region, periodoFloracion, uso)
        {
            this.region = region;
            this.periodoFloracion = periodoFloracion;
            this.uso = uso;
        }

        public string InfoAmbas()
        {
            string info = $"Uso: {uso}";
            return info;
        }

        public override string InformacionOrquidea()
        {
            string info = $"Esta orquidea proviene de la region: {region}.\nPeriodo de floracion {periodoFloracion}.";

            InfoAmbas();
            return info;
        }
    }
}

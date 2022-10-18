namespace MachineACaféI1
{
    public class MachineACafé
    {
        private bool _caféDisponible = true;
        private bool _gobeletsDisponibles = true;

        public void InsérerMonnaie(int nombreDeCentimes)
        {
            // ! Mutation
            if(EauDisponible && _caféDisponible && (_gobeletsDisponibles || TasseDetectée))
            {
                ArgentEncaisséEnCentimes = nombreDeCentimes;
                NombreCafésServis = 1;
            }

            NombreGobelets--;
            NombreDosesCafé--;
        }

        public int NombreCafésServis { get; private set; }
        public int ArgentEncaisséEnCentimes { get; private set; }
        public bool TasseDetectée { private get; init; }
        public int NombreGobelets { get; private set; }
        public bool EauDisponible { private get; init; } = true;
        public int NombreDosesCafé { get; private set; }

        public void ViderStockCafé()
        {
            _caféDisponible = false;
        }

        public void ViderStockGobelets()
        {
            _gobeletsDisponibles = false;
        }
    }
}
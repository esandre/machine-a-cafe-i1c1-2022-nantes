namespace MachineACaféI1
{
    public class MachineACafé
    {
        private bool _caféDisponible = true;
        private bool _gobeletsDisponibles = true;

        public void InsérerMonnaie(int nombreDeCentimes)
        {
            if(_caféDisponible && _gobeletsDisponibles)
            {
                ArgentEncaisséEnCentimes = nombreDeCentimes;
                NombreCafésServis = 1;
            }
        }

        public int NombreCafésServis { get; private set; }
        public int ArgentEncaisséEnCentimes { get; private set; }

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
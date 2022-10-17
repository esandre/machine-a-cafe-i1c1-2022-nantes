namespace MachineACaféI1
{
    public class MachineACafé
    {
        public void InsérerMonnaie(int nombreDeCentimes)
        {
            NombreCafésServis = 1;
            ArgentEncaisséEnCentimes = nombreDeCentimes;
        }

        public int NombreCafésServis { get; private set; }
        public int ArgentEncaisséEnCentimes { get; private set; }
    }
}
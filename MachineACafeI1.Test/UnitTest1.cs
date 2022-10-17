using MachineACaféI1;

namespace MachineACafeI1.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "QUAND on met 40cts ALORS un café coule")]
        public void TestCafé()
        {
            var machine = new MachineACafé();
            var cafésInitiaux = machine.NombreCafésServis;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS un café coule
            var cafésFinaux = machine.NombreCafésServis;
            Assert.Equal(cafésInitiaux + 1, cafésFinaux);
        }
        
        [Fact(DisplayName = "QUAND on met plus de 40cts ALORS un café coule ET tout l'argent est encaissé")]
        public void TestGardeLaMonnaie()
        {
            const int centimesInsérés = 40;

            var machine = new MachineACafé();
            var cafésInitiaux = machine.NombreCafésServis;
            var argentEncaisséInitial = machine.ArgentEncaisséEnCentimes;

            // QUAND on met 40cts
            machine.InsérerMonnaie(centimesInsérés);

            // ALORS un café coule
            var cafésFinaux = machine.NombreCafésServis;
            Assert.Equal(cafésInitiaux + 1, cafésFinaux);

            // ET tout l'argent est encaissé
            var argentEncaisséFinal = machine.ArgentEncaisséEnCentimes;
            Assert.Equal(argentEncaisséInitial + centimesInsérés, argentEncaisséFinal);

        }
    }
}
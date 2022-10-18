using MachineACaféI1;

namespace MachineACafeI1.Test
{
    public class UnitTest1
    {
        [Fact(DisplayName = "QUAND on met 40cts " +
                            "ALORS un café coule")]
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

        [Fact(DisplayName = "QUAND on met 40cts " +
                            "ALORS on décrémente de 1 le nombre de gobelets")]
        public void TestDécrémentationGobelets()
        {
            var machine = new MachineACafé();
            var gobeletsInitiaux = machine.NombreGobelets;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS on décrémente de 1 le nombre de gobelets
            var gobeletsFinaux = machine.NombreGobelets;
            Assert.Equal(gobeletsInitiaux - 1, gobeletsFinaux);
        }

        [Fact(DisplayName = "QUAND on met 40cts " +
                            "ALORS on décrémente de 1 le nombre de doses de café")]
        public void TestDécrémentationCafé()
        {
            var machine = new MachineACafé();
            var caféInitial = machine.NombreDosesCafé;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS on décrémente de 1 le nombre de doses de café
            var caféFinal = machine.NombreDosesCafé;
            Assert.Equal(caféInitial - 1, caféFinal);
        }

        [Fact(DisplayName = "QUAND on met plus de 40cts " +
                            "ALORS un café coule " +
                            "ET tout l'argent est encaissé")]
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
        
        [Fact(DisplayName = "ETANT DONNE qu'il n'y a plus de café " +
                            "QUAND on met 40cts " +
                            "ALORS l'argent est rendu")]
        public void TestPénurieCafé()
        {
            // ETANT DONNE qu'il n'y a plus de café
            var machine = new MachineACafé();
            machine.ViderStockCafé();

            var argentEncaisséInitial = machine.ArgentEncaisséEnCentimes;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS l'argent est rendu
            var argentEncaisséFinal = machine.ArgentEncaisséEnCentimes;
            Assert.Equal(argentEncaisséInitial, argentEncaisséFinal);
        }

        [Fact(DisplayName = "ETANT DONNE qu'il n'y a plus de gobelets " +
                            "QUAND on met 40cts " +
                            "ALORS l'argent est rendu " +
                            "ET aucun café n'est servi")]
        public void TestPénurieGobelets()
        {
            // ETANT DONNE qu'il n'y a plus de gobelets
            var machine = new MachineACafé();
            machine.ViderStockGobelets();

            var cafésInitiaux = machine.NombreCafésServis;
            var argentEncaisséInitial = machine.ArgentEncaisséEnCentimes;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS l'argent est rendu
            var argentEncaisséFinal = machine.ArgentEncaisséEnCentimes;
            Assert.Equal(argentEncaisséInitial, argentEncaisséFinal);

            // ET aucun café n'est servi
            var cafésFinaux = machine.NombreCafésServis;
            Assert.Equal(cafésInitiaux, cafésFinaux);
        }

        [Fact(DisplayName = "ETANT donné qu'une tasse est détectée " +
                            "QUAND on met 40cts " +
                            "ALORS le café coule " +
                            "ET aucun gobelet n'est consommé",
            Skip = "Test tautologique")]
        public void TestPasGobeletSiTasseDétectée()
        {
            // ETANT donné qu'une tasse est détectée
            var machine = new MachineACafé
            {
                TasseDetectée = true
            };

            var cafésInitiaux = machine.NombreCafésServis;
            var gobeletsInitiaux = machine.NombreGobelets;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS le café coule
            var cafésFinaux = machine.NombreCafésServis;
            Assert.Equal(cafésInitiaux + 1, cafésFinaux);

            // ET aucun gobelet n'est consommé
            var gobeletsFinaux = machine.NombreGobelets;
            Assert.Equal(gobeletsInitiaux, gobeletsFinaux);
        }

        [Fact(DisplayName = "ETANT donne qu'il n'y a plus de gobelets " +
              "ET qu'une tasse est détectée " +
              "QUAND on met 40cts " +
              "ALORS le café coule")]
        public void TestTasseContournePénurieGobelet()
        {
            // ETANT donné qu'une tasse est détectée
            var machine = new MachineACafé
            {
                TasseDetectée = true
            };

            var cafésInitiaux = machine.NombreCafésServis;

            // ET qu'il n'y a plus de gobelets
            machine.ViderStockGobelets();

            // QUAND on met 40 cts
            machine.InsérerMonnaie(40);
            
            // ALORS le café coule
            var cafésFinaux = machine.NombreCafésServis;
            Assert.Equal(cafésInitiaux + 1, cafésFinaux);
        }

        [Fact(DisplayName = "ETANT donné que la machine n'a plus d'eau " +
                            "QUAND on met 40cts " +
                            "ALORS l'argent est rendu")]
        public void TestPénurieEau()
        {
            // ETANT DONNE que la machine n'a plus d'eau
            var machine = new MachineACafé { EauDisponible = false };
            var argentEncaisséInitial = machine.ArgentEncaisséEnCentimes;

            // QUAND on met 40cts
            machine.InsérerMonnaie(40);

            // ALORS l'argent est rendu
            var argentEncaisséFinal = machine.ArgentEncaisséEnCentimes;
            Assert.Equal(argentEncaisséInitial, argentEncaisséFinal);
        }
    }
}
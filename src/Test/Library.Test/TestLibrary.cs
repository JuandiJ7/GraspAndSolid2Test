using NUnit.Framework;


namespace Library.Test //Lo que necesitamos probar es cada una de las clases que pertenecen al programa
{
    using System.Linq;
    using Full_GRASP_And_SOLID.Library;
    using System.Collections;

    public class Tests
    {        
        [Test]
        public void ProductTest() //Probamos la creacion y obtencion de un producto
        {
            Product Pan = new Product("Pan",20);
            Assert.AreEqual(Pan.Description,"Pan");
            Assert.AreEqual(Pan.UnitCost,20);
        }

        [Test]
        public void EquipmentTest() //Probamos la creacion y obtencion de un equipamiento
        {
            Equipment Cuchillo = new Equipment("Cuchillo",100);
            Assert.AreEqual(Cuchillo.Description,"Cuchillo");
            Assert.AreEqual(Cuchillo.HourlyCost,100);
        } 

        [Test]
        public void StepTest() //Probamos la creacion, obtencion y calculo de un step
        {
            Product Pan = new Product("Pan",20);
            Equipment Cuchillo = new Equipment("Cuchillo",100);
            Step paso1 = new Step(Pan,1,Cuchillo,1);
            Assert.AreEqual(paso1.Input,Pan);
            Assert.AreEqual(paso1.Quantity,1);
            Assert.AreEqual(paso1.Equipment,Cuchillo);
            Assert.AreEqual(paso1.Time,1);
            Assert.AreEqual(paso1.GetStepCost(),120);
        }

        [Test]

        public void RecipeTest() //Probamos la creación de una receta y su obtencion de texto
        {
            Recipe recipe = new Recipe();   
            recipe.FinalProduct = new Product ("BigMac", 150);
            Product Pan = new Product("Pan",20);
            Product Hamburguesa = new Product("Hamburguesa",50);
            Equipment Cuchillo = new Equipment("Cuchillo",100);
            Equipment Sarten = new Equipment("Sarten",100);
            Step paso1 = new Step(Pan,1,Cuchillo,1);
            Step paso2 = new Step(Hamburguesa,1,Sarten,10);
            recipe.AddStep(paso1);
            recipe.AddStep(paso2);

            
            string esperado = $"Receta de {recipe.FinalProduct.Description}:\n" + $"{paso1.Quantity} de '{paso1.Input.Description}' " +
                    $"usando '{paso1.Equipment.Description}' durante {paso1.Time}\n" + $"{paso2.Quantity} de '{paso2.Input.Description}' " +
                    $"usando '{paso2.Equipment.Description}' durante {paso2.Time}\n" + $"Costo de producción: {recipe.GetProductionCost()}"; 

            Assert.AreEqual(recipe.GetTextToPrint(), esperado);

        }
      
}
}
using System;
using Entidades;
using Entidades.Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void PaqueteCorreoTest()
        {
            //arrange
            Correo correo = new Correo();

            //act

            //assert
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaqueteDuplicadoest()
        {
            //arrange
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("direccion 1", "123");
            Paquete paquete2 = new Paquete("direccion 2", "123");

            //act
            correo += paquete1;
            correo += paquete2;

            //assert
        }
    }
}

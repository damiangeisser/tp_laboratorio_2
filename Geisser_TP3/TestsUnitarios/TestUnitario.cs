using System;
using ClasesInstanciables;
using ClasesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoExceptionTest()
        {
            //arrange
            
            //act
            Alumno a1 = new Alumno(10, "María", "Gonzales", "2000", Persona.ENacionalidad.Argentino,
                  Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetidoExceptionTest()
        {
            //arrange
            Universidad uni = new Universidad();

            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);

            //act
            uni += a4;
            uni += a4;
            //assert
        }

        [TestMethod]
        public void QueueNoNulaTest()
        {
            //arrange
            Universidad uni = new Universidad();

            //act

            //assert
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}

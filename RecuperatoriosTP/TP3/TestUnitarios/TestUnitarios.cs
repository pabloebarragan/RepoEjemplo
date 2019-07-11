using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {        
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void DniNacionalidadInvalido()
        {
            Alumno alumno = new Alumno(1, "Carolina", "Sanchez", "34444234", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);            
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidException))]
        public void DniValorInvalido()
        {
            string dniInvalido = "2AA43019";
            Alumno alumno = new Alumno(2, "Pity", "Martinez", dniInvalido, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        public void ApellidoValorInvalido()
        {
            string apellidoInvalido = "Se43asda";
            Alumno alumno = new Alumno(3, "Mariana", apellidoInvalido, "40121000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual("", alumno.Apellido);
        }

        [TestMethod]
        public void DniValorNumerico()
        {
            Alumno alumno = new Alumno(4, "Santiago", "Silva", "45000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }

        [TestMethod]
        public void ValoresNoNulos()
        {
            Alumno alumno = new Alumno(5, "Gonzalo", "Mora", "93434000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(alumno.Nombre);
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.DNI);
            Assert.IsNotNull(alumno.Nacionalidad);
        }
    }
}

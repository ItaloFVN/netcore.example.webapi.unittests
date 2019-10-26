using Microsoft.VisualStudio.TestTools.UnitTesting;
using netcore.example.webapi.unittests.Controllers;
using netcore.example.webapi.unittests.Models;
using netcore.example.webapi.unittests.Services;
using System.Collections.Generic;
using System.Linq;

namespace netcore.example.webapi.unittests.tests
{
    [TestClass]
    public class PessoasUnitTest
    {
        private const string MARCELO = "Marcelo";
        private const string MARCOS = "Marcos";
        private const string CRISTIANE = "Cristiane";

        #region Arrange
        private PessoasController _pessoasController = new PessoasController(new PessoasService());
        #endregion

        [TestMethod]
        public void TestCount()
        {
            #region Act
            IReadOnlyCollection<PessoaDto> pessoas = (IReadOnlyCollection<PessoaDto>)_pessoasController.GetByName(null);
            #endregion

            #region Assert
            Assert.AreEqual(pessoas.Count, 3);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(MARCELO)).ToList().Count == 1);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(MARCOS)).ToList().Count == 1);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(CRISTIANE)).ToList().Count == 1);
            #endregion
        }

        [TestMethod]
        public void TestTermM()
        {
            #region Act
            IReadOnlyCollection<PessoaDto> pessoas = (IReadOnlyCollection<PessoaDto>)_pessoasController.GetByName("M");
            #endregion

            #region Assert
            Assert.AreEqual(pessoas.Count, 2);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(MARCELO)).ToList().Count == 1);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(MARCOS)).ToList().Count == 1);
            #endregion
        }

        [TestMethod]
        public void TestTermCris()
        {
            #region Act
            IReadOnlyCollection<PessoaDto> pessoas = (IReadOnlyCollection<PessoaDto>)_pessoasController.GetByName("Cris");
            #endregion

            #region Assert
            Assert.AreEqual(pessoas.Count, 1);
            Assert.IsTrue(pessoas.Where(p => p.Nome.Contains(CRISTIANE)).ToList().Count == 1);
            #endregion
        }

        [TestMethod]
        public void TestTermJoao()
        {
            #region Act
            IReadOnlyCollection<PessoaDto> pessoas = (IReadOnlyCollection<PessoaDto>)_pessoasController.GetByName("João");
            #endregion

            #region Assert
            Assert.AreEqual(pessoas.Count, 0);
            #endregion
        }
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vote.DAO.DataAccess;

namespace Vote.Tests.DataAccess
{
    [TestClass]
    public class CategoriaDataAccessTest
    {
        [TestMethod]
        public void RetornaTodasCategorias()
        {
            CategoriaDataAccess catDao = new CategoriaDataAccess();

            Assert.AreNotEqual(catDao.All.Count(), 0);
        }
    }
}

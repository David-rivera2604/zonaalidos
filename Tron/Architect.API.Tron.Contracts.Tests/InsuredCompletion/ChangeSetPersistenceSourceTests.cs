using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Architect.API.Tron.Contracts.Tests.InsuredCompletion
{
    /// <summary>
    /// Verifica que la auditoría de entidades existentes persista sus eventos.
    /// </summary>
    [TestClass]
    public class ChangeSetPersistenceSourceTests
    {
        /// <summary>
        /// Exige insertar el evento construido por la primera sobrecarga de ChangeSet.
        /// </summary>
        [TestMethod]
        public void ChangeSetDeEntidadExistente_PersisteElRegistroCreado()
        {
            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
            string source = File.ReadAllText(Path.Combine(root, "Core", "Architect.API.Core.Business", "General", "ChangeSet.cs"));

            StringAssert.Contains(source, "Core.DataAccess.General.ChangeSet.Create(item);");
            Assert.IsFalse(source.Contains("//item.Id = Core.DataAccess.General.ChangeSet.Create(item);"));
        }
    }
}

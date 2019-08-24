using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleApp;

namespace PuzzleTests
{
    [TestClass]
    public class CellIndicesTests
    {
        private readonly CellIndices Lhs = new CellIndices(1, 1),
                                     Rhs = new CellIndices(2, 3);


        [TestMethod]
        public void OperatorEquals()
        {
            Assert.IsFalse(Lhs == Rhs);

        }

        [TestMethod]
        public void OperatorNotEquals()
        {
            Assert.IsTrue(Lhs != Rhs);

        }

        [TestMethod]
        public void EqualsMemberFunction()
        {
            Assert.IsFalse(Lhs.Equals(Rhs));

        }

        [TestMethod]
        public void AreHashCodesDifferent()
        {
            var LhsHash = Lhs.GetHashCode();
            var RhsHash = Rhs.GetHashCode();

            Assert.AreNotEqual(LhsHash, RhsHash);

        }

    }

}

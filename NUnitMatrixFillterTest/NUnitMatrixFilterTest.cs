using System;
using NUnit.Framework;
using MatrixSortTools;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;


namespace NUnitMatrixFillterTest
{
    [TestFixture]
    public class NUnitMatrixFilterTest
    {

        [Test]
        public void TestGrowingSum()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3, 5 };
            matrix[1] = new int[] { 11, 2, -3, 5, 99 };
            matrix[2] = new int[] { 0, 122, -481 };

            matrix.Filter(new GrowingSumComparer());

            int[][] actual = matrix;

            int[][] expected = new int[3][];
            expected[2] = new int[] { 11, 2, -3, 5, 99 };
            expected[1] = new int[] { 1, 2, 3, 5 };
            expected[0] = new int[] { 0, 122, -481 };

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestGrowingMinElements()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3, 5 };
            matrix[1] = new int[] { 11, 2, -3, 5, 99 };
            matrix[2] = new int[] { 0, 122, -481 };

            matrix.Filter(new GrowingMinElementComparer());

            int[][] actual = matrix;

            int[][] expected = new int[3][];
            expected[1] = new int[] { 11, 2, -3, 5, 99 };
            expected[2] = new int[] { 1, 2, 3, 5 };
            expected[0] = new int[] { 0, 122, -481 };

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestDecreasingMaxElement()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 2, 3, 5 };
            matrix[1] = new int[] { 11, 2, -3, 5, 99 };
            matrix[2] = new int[] { 0, 122, -481 };

            matrix.Filter(new DecreasingMaxElementComparer());

            int[][] actual = matrix;

            int[][] expected = new int[3][];
            expected[1] = new int[] { 11, 2, -3, 5, 99 };
            expected[2] = new int[] { 1, 2, 3, 5 };
            expected[0] = new int[] { 0, 122, -481 };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}


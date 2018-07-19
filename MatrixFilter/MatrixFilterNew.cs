using MatrixSortTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixFilter
{
    public static class MatrixExtention
    {

        /// <summary>
        /// Filters the specified comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Filter<T>(this T[] array, Func<T,T,int> comparer)
        {
            void Validate()
            {
                if (array == null)
                {
                    throw new ArgumentNullException();
                }

                if (array.Length == 0)
                {
                    throw new ArgumentException();
                }

                if (comparer == null)
                {
                    throw new ArgumentNullException();
                }
            }

            array.Filter(new Adapter<T>(comparer));
        }

        /// <summary>
        /// Filters the specified comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Filter<T>(this T[] array, IComparer<T> comparer)
        {
            Validate(array, comparer);
            

            bool flag = true;

            while (flag)
            {
                flag = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (comparer.Compare(array[i], array[i + 1]) > 0)
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        flag = true;
                    }

                }
            }
        }

        /// <summary>
        /// Swaps the specified a.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Validates the specified array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="System.ArgumentNullException">array
        /// or
        /// comparer</exception>
        /// <exception cref="System.ArgumentException"></exception>
        private static void Validate<T>(T[] array, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
        }
    }

    /// <summary>
    /// Class-adapter for delegate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IComparer{T}" />
    public class Adapter<T> : IComparer<T>
    {
        private Func<T, T, int> comparer;


        public Adapter(Func<T, T, int> comparer)
        {
            this.comparer = comparer ?? throw new ArgumentNullException();
        }

        public int Compare(T x, T y) => comparer(x, y);
    }
}


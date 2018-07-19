using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSortTools
{
    public class GrowingSumComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.Sum() > y.Sum())
            {
                return 1;
            }

            if (x.Sum() < y.Sum())
            {
                return -1;
            }

            return 0;
        }
    }


    public class DecreasingSumComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.Sum() < y.Sum())
            {
                return 1;
            }

            if (x.Sum() > y.Sum())
            {
                return -1;
            }

            return 0;
        }
    }

    public class DecreasingMaxElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.Max() < y.Max())
            {
                return 1;
            }

            if (x.Max() > y.Max())
            {
                return -1;
            }

            return 0;
        }
    }

    public class GrowingMaxElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.Max() > y.Max())
            {
                return 1;
            }

            if (x.Max() < y.Max())
            {
                return -1;
            }

            return 0;
        }
    }
    


    public class GrowingMinElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.Min() > y.Min())
            {
                return 1;
            }

            if (x.Min() < y.Min())
            {
                return -1;
            }

            return 0;
        }
    }

    public class DecreasingMinElementComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.Min() < y.Min())
            {
                return 1;
            }

            if (x.Min() > y.Min())
            {
                return -1;
            }

            return 0;
        }
    }
}

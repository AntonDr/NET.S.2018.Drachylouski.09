using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSortTools
{
    public class GrowingSumComparer : IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Sum() - seconditem.Sum() > 0);

    }

    public class DecreasingSumComparer : IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Sum() - seconditem.Sum() < 0);
    }

    public class DecreasingMaxElementComparer : IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Max() - seconditem.Max() < 0);
    }

    public class GrowingMaxElementComparer : IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Max() - seconditem.Max() > 0);
    }

    public class GrowingMinElementComparer: IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Min() - seconditem.Min() > 0);
    }

    public class DecreasingMinElementComparer : IComparer<int>
    {
        public bool Compare(int[] firstitem, int[] seconditem) => (firstitem.Max() - seconditem.Max() < 0);
    }
}

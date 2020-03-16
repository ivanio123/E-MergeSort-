using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

namespace SortTest
{
    class StudSort
    {
        static void Merge(ValueType[] data, int leftIndex, int middleIndex, int rightIndex)
        {
            int left = leftIndex;
            int right = middleIndex + 1;
            ValueType [] tempData = new ValueType[rightIndex - leftIndex + 1];
            int indexTemp = 0;

            while ((left <= middleIndex) && (right <= rightIndex))
            {
                if (data[left] < data[right])
                {
                    tempData[indexTemp] = data[left];
                    left++;
                }
                else
                {
                    tempData[indexTemp] = data[right];
                    right++;
                }

                indexTemp++;
            }

            for (int i = left; i <= middleIndex; i++)
            {
                tempData[indexTemp] = data[i];
                indexTemp++;
            }

            for (int i = right; i <= rightIndex; i++)
            {
                tempData[indexTemp] = data[i];
                indexTemp++;
            }

            for (int i = 0; i < tempData.Length; i++)
            {
                data[leftIndex + i] = tempData[i];
            }
        }

        //сортировка слиянием
        static ValueType[] MergeSort(ValueType[] data, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(data, leftIndex, middleIndex);
                MergeSort(data, middleIndex + 1, rightIndex);
                Merge(data, leftIndex, middleIndex, rightIndex);
            }

            return data;
        }

        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            return MergeSort(data, 0, data.Length - 1);
        }
    }
}

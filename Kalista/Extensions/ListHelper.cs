using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista
{
    public static class ListExtension
    {
        public static List<T> GetRandomList<T>(this List<T> inputList)
        {
            //Copy to a array
            T[] copyArray = new T[inputList.Count];
            inputList.CopyTo(copyArray);

            //Add range
            List<T> copyList = new List<T>();
            copyList.AddRange(copyArray);

            //Set outputList and random
            List<T> outputList = new List<T>();
            Random rd = new Random(DateTime.Now.Millisecond);

            while (copyList.Count > 0)
            {
                //Select an index and item
                int rdIndex = rd.Next(0, copyList.Count - 1);
                T remove = copyList[rdIndex];

                //remove it from copyList and add it to output
                copyList.Remove(remove);
                outputList.Add(remove);
            }
            return outputList;
        }

        public static List<string> GetRandomStaffList(List<string> list)
        {
            list = list.GetRandomList();
            int eI = list.IndexOf("Eki");
            int mI = list.IndexOf("Mori");
            if(Math.Abs(eI-mI) != 1)
            {
                if (eI < mI)
                {
                    list[eI] = list[mI - 1];
                    list[mI - 1] = "Eki";
                }
                else
                {
                    list[mI] = list[eI - 1];
                    list[eI - 1] = "Mori";
                }
            }
            return list;
        }
    }
}

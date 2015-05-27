using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    /// <summary>
    /// Helper class for operations on collections
    /// </summary>
    public static class OperationHelper
    {
        /// <summary>
        /// Method returns true if lists are equal
        /// </summary>
        /// <typeparam name="T">Type of elements used in collection</typeparam>
        /// <param name="list1">Source collection</param>
        /// <param name="list2">Target collection</param>
        /// <returns>True if collections are equal</returns>
        public static bool CheckEquality<T>(IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 == null ^ list2 == null)
            {
                return false;
            }

            if (list1 != null && list2 != null)
            {
                return (!list1.Except(list2).Any() && !list1.Except(list2).Any());
            }

            return true;
        }

        /// <summary>
        /// Method returns hashcode from given list
        /// </summary>
        /// <typeparam name="T">Type used in list</typeparam>
        /// <param name="list">List to calculate hashfrom</param>
        /// <returns>Hashcode from given list, zero if list is null</returns>
        public static int GetHash<T>(IEnumerable<T> list)
        {
            int hash = 0;

            if (list != null)
            {
                hash = list.Aggregate(0, (el1, el2) => GetHashCodeFromObject(el1) ^ GetHashCodeFromObject(el2));
            }           

            return hash;
        }

        /// <summary>
        /// Method retuns hashcode from given object
        /// </summary>
        /// <param name="obj">Object to calculate hashcode from</param>
        /// <returns>Hashcode from given object, zero if object is null</returns>
        public static int GetHashCodeFromObject(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Softscape.Infrastructure.PCL.NET
{
	public static class CollectionExtensions
	{
		public static void AddRange<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> rangeList)
		{
			foreach (var item in rangeList)
			{
				observableCollection.Add(item);
			}
		}

		public static int Remove<T>(this ObservableCollection<T> coll, Func<T, bool> condition)
		{
			var itemsToRemove = coll.Where(condition).ToList();

			foreach (var itemToRemove in itemsToRemove)
			{
				coll.Remove(itemToRemove);
			}

			return itemsToRemove.Count;
			/*
			 * 
			 * for (int i = collection.Count - 1; i >= 0; i--)
        {
            if (condition(collection[i]))
            {
                collection.RemoveAt(i);
            }
        }
			 */
		}
	}
}

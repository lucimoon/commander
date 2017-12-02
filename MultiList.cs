using UnityEngine;
using System.Collections.Generic;

public class MultiList<T> {
  private List<List<T>> lists;

  public MultiList() {
    lists = new List<List<T>>();
  }

  public int Count {
    get {
      return totalCount();
    }
  }

  public int ListCount {
    get {
      return this.lists.Count;
    }
  }

  public void Add (int listIndex, T newItem) {
    lists[listIndex].Add(newItem);
  }

  public void AddList (List<T> newList) {
    lists.Add(newList);
  }

  public T RandomItem() {
    int randomCount = (int)Mathf.Ceil(Random.value * this.Count);
    int currentCount = 0;
    int index = 0;
    bool countWithinList = false;
    T randomItem = default(T);

    foreach (var list in this.lists) {
      countWithinList = randomCount <= currentCount + list.Count;

      if (countWithinList) {
        index = randomCount - currentCount - 1;
        randomItem = list[index];
      } else {
        currentCount += list.Count;
      }
    }

    return randomItem;
  }

  private int totalCount () {
    int total = 0;

    foreach (var list in lists) {
      total += list.Count;
    }

    return total;
  }
}
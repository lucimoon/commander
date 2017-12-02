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
    int randomIndex = (Random.Range(0, this.Count));
    bool indexWithinList = false;
    T randomItem = default(T);

    foreach (var list in this.lists) {
      indexWithinList = randomIndex < list.Count;

      if (indexWithinList) {
        return randomItem = list[randomIndex];
      } else {
        randomIndex -= list.Count;
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
using UnityEngine;
using System.Collections.Generic;

public class Sight {
  private List<GameObject> visibleObjects;

  public Sight (GameObject gameObject) {
    visibleObjects = new List<GameObject>();
  }

  public List<GameObject> SensedObjects {
    get {
      return visibleObjects;
    }
  }

  public void Sense (GameObject otherObject) {
    bool visible = IsVisible(otherObject);

    // if within field of vision
    if (visible) {
      // add to list of visible objects
      Debug.Log("Visible: " + otherObject);
      visibleObjects.Add(otherObject);
    } else {
      Unsense(otherObject);
    }
  }

  private bool IsVisible (GameObject otherObject) {
    // test if the object is within field of vision
    return true;
  }

  public void Unsense (GameObject otherObject) {
    if (visibleObjects.Contains(otherObject)) {
      Debug.Log("Invisible: " + otherObject);
      visibleObjects.Remove(otherObject);
    }
  }
}
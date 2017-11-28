using UnityEngine;

public class Senses {
  private GameObject gameObject;
  private Vector3 destination;

  public Senses () {
    Debug.Log("WARNING: Senses needs GameObject.");
  }

  public Senses (GameObject gameObject) {
    this.gameObject = gameObject;
  }

  public Vector3 Location {
    get {
      return this.gameObject.transform.position;
    }
  }
}
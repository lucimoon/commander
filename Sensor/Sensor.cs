using UnityEngine;
using System.Collections.Generic;

public class Sensor : MonoBehaviour {
  private Vector3 destination;
  public float maxSensorDistance = 20f;
  private Sight sight;
  private SphereCollider sensor;
  private List<ICommand> commands;
  private ICommander commander;

  void Start () {
    sensor = gameObject.AddComponent<SphereCollider>();
    sensor.isTrigger = true;
    sensor.radius = maxSensorDistance;

    sight = new Sight();
    touch = new Touch();
  }

  void OnTriggerEnter(Collider otherCollider) {
    sight.Sense(otherCollider.gameObject);
  }

  void OnTriggerExit(Collider otherCollider) {
    IInteractable interactableObject = otherCollider.gameObject.GetComponent<IInteractable>();
    if (interactableObject != null) {
      sight.Unsense(interactableObject, otherCollider.gameObject);
    }
  }

  public Vector3 Location {
    get {
      return this.gameObject.transform.position;
    }
  }

  public List<ICommand> SensedCommands {
    get {
      // if (typeof(IPickupable) == obj) {

      // }
      return sight.SensedCommands;
    }
  }

  public List<GameObject> SensedObjects {
    get {
      return sight.SensedObjects;
    }
  }

  public Vector3 InterestingObjectLocation {
    get {
      if (this.SensedObjects.Count > 0) {
        return this.SensedObjects[Random.Range(0, this.SensedObjects.Count)].transform.position;
      }

      return LeftOrRight();
    }
  }

  private Vector3 LeftOrRight () {
    List<Vector3> leftRight = new List<Vector3>(new Vector3[] {transform.right, -transform.right});
    return leftRight[Random.Range(0, 2)] * 10;
  }

  public GameObject Self {
    get {
      return this.gameObject;
    }
  }
}
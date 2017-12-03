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
      return sight.SensedCommands;
    }
  }

  public List<GameObject> SensedObjects {
    get {
      return sight.SensedObjects;
    }
  }
}
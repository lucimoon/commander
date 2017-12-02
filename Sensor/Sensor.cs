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
    sensor.radius = maxSensorDistance;

    sight = new Sight(gameObject);
  }

  void OnTriggerStay(Collider otherCollider) {
    sight.Sense(otherCollider.gameObject);
  }

  void OnTriggerExit(Collider otherCollider) {
    sight.Unsense(otherCollider.gameObject);
  }

  public Vector3 Location {
    get {
      return this.gameObject.transform.position;
    }
  }

  public List<GameObject> VisibleObjects {
    get {
      return sight.SensedObjects;
    }
  }
}
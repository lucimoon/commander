using UnityEngine;
using System.Collections.Generic;

public class Touch {
  private List<ICommand> sensedCommands;
  private List<GameObject> sensedObjects;
  private Sensor sensor;

  public Touch (Sensor sensor) {
    sensedCommands = new List<ICommand>();
    sensedObjects = new List<GameObject>();
    this.sensor = sensor;
  }

  public List<ICommand> SensedCommands {
    get {
      return sensedCommands;
    }
  }

  public List<GameObject> SensedObjects {
    get {
      return sensedObjects;
    }
  }

  public void Sense (GameObject otherObject) {
    ITouchable touchableObject = otherObject.GetComponent<ITouchable>();
    if (touchableObject == null) return;

    bool isWithinReach = IsWithinReach(otherObject);

    if (!isWithinReach) Unsense(otherObject);

    if (isWithinReach) {
      if (!sensedObjects.Contains(otherObject)) {
        sensedObjects.Add(otherObject);
        sensedCommands.AddRange(touchableObject.Interactions);
      }
    }
  }

  private bool IsWithinReach (GameObject touchableObject) {
    // TODO: test if object is in front
    float distance = Vector3.Magnitude(touchableObject.transform.position - sensor.Location);
    if (distance < 2f) return true;

    return false;
  }

  public void Unsense (GameObject otherObject) {
    bool removed = sensedObjects.Remove(otherObject);

    if (removed) {
      touchableObject.Interactions.ForEach((command) => {
        sensedCommands.Remove(command);
      });

      sensedObjects.TrimExcess();
      sensedCommands.TrimExcess();
    }
  }
}
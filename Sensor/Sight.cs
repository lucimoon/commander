using UnityEngine;
using System.Collections.Generic;

public class Sight {
  private List<ICommand> sensedCommands;
  private List<GameObject> sensedObjects;

  public Sight () {
    sensedCommands = new List<ICommand>();
    sensedObjects = new List<GameObject>();
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
    IInteractable interactableObject = otherObject.GetComponent<IInteractable>();
    if (interactableObject == null) return;

    bool visible = IsVisible(otherObject);

    if (!visible) Unsense(interactableObject, otherObject);

    if (visible) {
      if (!sensedCommands.Contains(otherObject)) {
        sensedObjects.Add(otherObject);
        sensedCommands.Add(interactableObject.InteractionCommand);
      }
    }
  }

  private bool IsVisible (IInteractable interactableObject) {
    // test if the object is within field of vision
    return true;
  }

  public void Unsense (IInteractable interactableObject, GameObject otherObject) {
    if (sensedCommands.Contains(interactableObject.InteractionCommand)) {
      sensedObjects.Remove(otherObject);
      sensedObjects.TrimExcess();
    }

    interactableObject.Interactions.ForEach((command) => {
      sensedCommands.Remove(command);
    });
    sensedCommands.TrimExcess();
  }
}
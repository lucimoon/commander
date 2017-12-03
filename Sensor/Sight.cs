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
    bool visible = IsVisible(interactableObject);

    if (sensedCommands.Contains(interactableObject.InteractionCommand)) {
      if (!visible) {
        Unsense(interactableObject, otherObject);
      }
    }

    if (visible) {
      if (!sensedCommands.Contains(interactableObject.InteractionCommand)) {
        sensedCommands.Add(interactableObject.InteractionCommand);
        sensedObjects.Add(otherObject);
      }
    }
  }

  private bool IsVisible (IInteractable interactableObject) {
    // test if the object is within field of vision
    return true;
  }

  public void Unsense (IInteractable interactableObject, GameObject otherObject) {
    if (sensedCommands.Contains(interactableObject.InteractionCommand)) {
      sensedCommands.Remove(interactableObject.InteractionCommand);
      sensedCommands.TrimExcess();
      sensedObjects.Remove(otherObject);
      sensedObjects.TrimExcess();
    }
  }
}
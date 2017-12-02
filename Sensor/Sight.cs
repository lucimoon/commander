using UnityEngine;
using System.Collections.Generic;

public class Sight {
  private List<ICommand> sensedCommands;

  public Sight () {
    sensedCommands = new List<ICommand>();
  }

  public List<ICommand> SensedCommands {
    get {
      return sensedCommands;
    }
  }

  public void Sense (IInteractable interactableObject) {
    bool visible = IsVisible(interactableObject);

    if (sensedCommands.Contains(interactableObject.InteractionCommand)) {
      if (!visible) {
        Unsense(interactableObject);
      }
    }

    if (visible) {
      if (!sensedCommands.Contains(interactableObject.InteractionCommand)) {
        sensedCommands.Add(interactableObject.InteractionCommand);
        Debug.Log("Visible: " + sensedCommands.Count);
      }
    }
  }

  private bool IsVisible (IInteractable interactableObject) {
    // test if the object is within field of vision
    return true;
  }

  public void Unsense (IInteractable interactableObject) {
    if (sensedCommands.Contains(interactableObject.InteractionCommand)) {
      Debug.Log("Invisible: " + interactableObject);
      sensedCommands.Remove(interactableObject.InteractionCommand);
    }
  }
}
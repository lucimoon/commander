using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : MonoBehaviour, ICommander, IInteractable {
  private List<ICommand> commands;
  private BoxController controller;
  private Interact interactCommand;

  public Command InteractionCommand () {
    return interactCommand;
  }

  void Start () {
    commands = new List<ICommand>();
    interactCommand = new Interact(this);
  }

  public List<ICommand> Commands {
    get {
      return commands;
    }
  }
}
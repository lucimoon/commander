using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : Commander, ICommander, IInteractable {
  private MultiList<ICommand> commands;
  private BoxController controller;
  private Interact interactCommand;
  private List<ICommand> interactionCommands;

  void Start () {
    commands = new MultiList<ICommand>();
    interactCommand = new Interact(this, interactionCommands);
  }

  public MultiList<ICommand> Commands {
    get {
      return commands;
    }
  }

  public ICommand InteractionCommand {
    get {
      return interactCommand;
    }
  }

  public List<ICommand> Interactions {
    get {
      return interactionCommands;
    }
  }

}
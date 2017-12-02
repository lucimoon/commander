using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : Commander, ICommander, IInteractable {
  private MultiList<ICommand> commands;
  private BoxController controller;
  private Interact interactCommand;
  private List<ICommand> interactionCommands;
  private ChangeColor changeColor;

  void Start () {
    commands = new MultiList<ICommand>();
    controller = GetComponent<BoxController>();
    interactionCommands = new List<ICommand>();
    LoadCommands();
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

  private void LoadCommands () {
    this.interactCommand = new Interact(this, interactionCommands);
    commands.AddList(this.interactionCommands);

    // Basic Commands
    this.changeColor = new ChangeColor(this.controller);
    this.interactionCommands.Add(this.changeColor);
    // Macro Commands

    // Add randomizable commands to list

  }
}
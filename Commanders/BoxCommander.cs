using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : Commander, ICommander, IInteractable {
  private MultiList<ICommand> commands;
  private BoxController controller;
  private Interact interactionCommand;
  private ChangeColor changeColor;
  private ChangeSize changeSize;
  private List<ICommand> interactions;

  void Start () {
    commands = new MultiList<ICommand>();
    controller = GetComponent<BoxController>();
    interactionCommand = new Interact();
    interactions = new List<ICommand>();
    LoadCommands();
  }

  public List<ICommand> Interactions {
    get {
      return this.interactions;
    }
  }

  public ICommand InteractionCommand {
    get {
      return this.interactionCommand;
    }
  }

  public MultiList<ICommand> Commands {
    get {
      return commands;
    }
  }

  private void LoadCommands () {
    commands.AddList(interactions);

    // Basic Commands
    this.changeColor = new ChangeColor(this.controller);
    this.changeSize = new ChangeSize(this.controller);

    // Macro Commands

    // Add randomizable commands to list
    this.interactions.Add(this.changeColor);
    this.interactions.Add(this.changeSize);

  }
}
using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : Commander, ICommander, IInteractable {
  private MultiList<ICommand> commands;
  private BoxController controller;
  private Interact interactionCommand;
  private ChangeColor changeColor;
  private ChangeSize changeSize;
  private ChangeSizeColor changeSizeColor;
  private ComeToMe comeToMe;
  private Duplicate duplicate;
  private List<ICommand> interactions;

  void Start () {
    commands = new MultiList<ICommand>();
    controller = GetComponent<BoxController>();
    interactionCommand = new ComeToMe();
    interactions = new List<ICommand>();
    LoadCommands();
  }

  public List<ICommand> Interactions {
    get {
      return this.interactions;
    }
  }

  public ICommand InteractionCommand(ICommander interactingCommander) {
    return new ComeToMe(interactingCommander);
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
    this.changeSizeColor = new ChangeSizeColor(this.controller);
    this.duplicate = new Duplicate(this.controller);

    // Macro Commands

    // Add randomizable commands to list
    this.interactions.Add(this.changeColor);
    this.interactions.Add(this.changeSize);
    this.interactions.Add(this.changeSizeColor);
    this.interactions.Add(this.duplicate);

  }
}
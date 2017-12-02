using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : MonoBehaviour, ICommander, IInteractable {
  private MultiList<ICommand> commands;
  private BoxController controller;
  private Interact interactCommand;
  private List<ICommand> interactionCommands;

  public Command InteractionCommand () {
    return interactCommand;
  }

  void Start () {
    commands = new MultiList<ICommand>();
    interactCommand = new Interact(this);
  }

  public MultiList<ICommand> Commands {
    get {
      return commands;
    }
  }

  public List<ICommand> Interactions {
    get {
      return interactions;
    }
  }

  public ICommand RandomInteraction () {
    int randomIndex = this.RandomInteractionIndex();
    return this.interactions[randomIndex];
  }

  private int RandomInteractionIndex () {
    return (int)Mathf.Round(Random.value * (this.interactions.Count - 1));
  }
}
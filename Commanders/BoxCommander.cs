using UnityEngine;
using System.Collections.Generic;

public class BoxCommander : MonoBehaviour, ICommander, IInteractable {
  private List<ICommand> commands;
  private BoxController controller;
  private Interact interactCommand;
  private List<ICommand> interactions;

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
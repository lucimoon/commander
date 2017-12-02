using UnityEngine;
using System.Collections.Generic;

public class CharacterCommander : MonoBehaviour, ICommander {
  public Queue<ICommand> activeCommands;
  public ThirdPersonCtrl controller;
  public GoToLocation GoToLocation;
  public GoToRandomLocation GoToRandomLocation;
  public Wait Wait;
  public ICommand currentCommand;

  private Sensor sensor;
  private bool idle = true;
  private MultiList<ICommand> commands;
  private List<ICommand> characterCommands;
  private List<ICommand> interactionCommands;

  void Start () {
    this.controller = GetComponent<ThirdPersonCtrl>();
    this.sensor = GetComponent<Sensor>();
    this.activeCommands = new Queue<ICommand>();
    this.commands = new MultiList<ICommand>();
    this.characterCommands = new List<ICommand>();
    this.interactionCommands = new List<ICommand>();

    this.LoadCommands();
  }

  void Update () {
    if (idle) {
      idle = false;

      if (activeCommands.Count == 0) {
        this.EnqueueCommand();
      }

      this.currentCommand = activeCommands.Peek();
      this.Execute(this.currentCommand, this.ExecutionCallback);
    }
  }

  private void LoadCommands () {
    int characterCommandsIndex = 0;
    int interactionCommandsIndex = 1;
    commands.AddList(characterCommands);
    commands.AddList(interactionCommands);

    // Basic Commands
    this.Wait = new Wait();
    this.GoToLocation = new GoToLocation(this, controller, this.sensor);

    // Macro Commands
    this.GoToRandomLocation = new GoToRandomLocation(this);

    // Add randomizable commands to list
    this.commands.Add(characterCommandsIndex, this.GoToRandomLocation);

    // this.commands.Add(new Greet(this.controller));
    // this.commands.Add(new WalkForward(this.controller));
  }

  private void EnqueueCommand () {
    // commands.Update(sensor);
    activeCommands.Enqueue(this.RandomCommand);
    activeCommands.Enqueue(this.Wait);`
  }

  public ICommand RandomCommand {
    get {
      return this.commands.RandomItem();
    }
  }

  public void ExecutionCallback () {
    this.idle = true;
    this.activeCommands.Dequeue();
  }

  public MultiList<ICommand> Commands {
    get {
      return commands;
    }
  }

  public void Execute (ICommand command, System.Action callback) {
    // Debug.Log(command.GetType().Name);
    StartCoroutine(command.Execute(callback));
  }
}
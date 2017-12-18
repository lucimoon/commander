using UnityEngine;
using System.Collections.Generic;

public class CharacterCommander : Commander, ICommander {
  public Queue<ICommand> activeCommands;
  public ThirdPersonCtrl controller;
  public GoToLocation GoToLocation;
  public GoToRandomLocation GoToRandomLocation;
  public Interaction Interaction;
  public Wait Wait;
  public Stare Stare;
  public ICommand currentCommand;

  private Sensor sensor;
  private bool idle = true;
  private MultiList<ICommand> commands;
  private List<ICommand> characterCommands;
  private List<ICommand> interactionCommands;
  private int characterCommandsIndex = 0;

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
    commands.AddList(characterCommands);
    commands.AddList(interactionCommands);

    // Basic Commands
    this.Wait = new Wait();
    this.GoToLocation = new GoToLocation(this, controller, this.sensor);

    // Macro Commands
    this.Stare = new Stare(this, controller, this.sensor);
    this.GoToRandomLocation = new GoToRandomLocation(this, this.sensor);
    this.Interaction = new Interaction(this, this.sensor);

    // Add randomizable commands to list
    this.commands.Add(characterCommandsIndex, this.GoToRandomLocation);
    // this.commands.Add(characterCommandsIndex, this.Interaction);
    this.commands.Add(characterCommandsIndex, this.Stare);

    // this.commands.Add(new Greet(this.controller));
  }

  private void EnqueueCommand () {
    activeCommands.Enqueue(this.RandomCommand);
    this.EnqueueWait();
  }

  private void EnqueueWait () {
    this.Wait.SetRandomTime();
    activeCommands.Enqueue(this.Wait);
  }
  public ICommand RandomCommand {
    get {
      this.UpdateInteractions();
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

  public void UpdateInteractions () {
    interactionCommands.Clear();
    interactionCommands.AddRange(sensor.SensedCommands);
  }
}
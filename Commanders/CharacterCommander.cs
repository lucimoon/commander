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
  private List<ICommand> commands;

  void Start () {
    this.controller = GetComponent<ThirdPersonCtrl>();
    this.sensor = GetComponent<Sensor>();
    this.activeCommands = new Queue<ICommand>();
    this.commands = new List<ICommand>();

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
    // Basic Commands
    this.Wait = new Wait();
    this.GoToLocation = new GoToLocation(this, controller, this.sensor);

    // Macro Commands
    this.GoToRandomLocation = new GoToRandomLocation(this);

    // Add randomizable commands to list
    this.commands.Add(this.GoToRandomLocation);

    // this.commands.Add(new Greet(this.controller));
    // this.commands.Add(new WalkForward(this.controller));
  }

  private void EnqueueCommand () {
    // commands.Update(sensor);
    activeCommands.Enqueue(this.RandomCommand());
    activeCommands.Enqueue(this.Wait);
  }

  public ICommand RandomCommand () {
    int randomIndex = this.RandomCommandIndex();
    // if (randomIndex > this.commands.Count - 1);
    return this.commands[randomIndex];
  }

  private int RandomCommandIndex () {
    return (int)Mathf.Round(Random.value * (this.commands.Count - 1));
  }

  private void ExecutionCallback () {`
    this.idle = true;
    this.activeCommands.Dequeue();
  }

  public List<ICommand> Commands {
    get {
      return commands;
    }
  }

  public void Execute (ICommand command, System.Action callback) {
    // Debug.Log(command.GetType().Name);
    StartCoroutine(command.Execute(callback));
  }
}
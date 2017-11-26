using UnityEngine;
using System.Collections.Generic;

public class Commander: MonoBehaviour {
  public List<ICommand> commands;
  public Queue<ICommand> activeCommands;
  public ThirdPersonCtrl controller;
  public Autonomy autonomy;

  public GoToLocation GoToLocation;
  public GoToRandomLocation GoToRandomLocation;
  public Wait Wait;
  public ICommand currentCommand;

  private bool idle = true;

  void Start () {
    this.controller = GetComponent<ThirdPersonCtrl>();
    this.autonomy = GetComponent<Autonomy>();
    this.commands = new List<ICommand>();
    this.activeCommands = new Queue<ICommand>();
    this.LoadCommands();
  }

  void Update () {
    if (idle) {
      idle = false;

      if (activeCommands.Count == 0) {
        this.EnqueueCommand();
      }

      this.currentCommand = activeCommands.Peek();
      Debug.Log(currentCommand.GetType().Name);
      StartCoroutine(this.currentCommand.Execute(this.ExecutionCallback));
    }
  }

  private void LoadCommands () {
    this.Wait = new Wait();

    this.GoToLocation = new GoToLocation(this);
    this.commands.Add(this.GoToLocation);


    // this.GoToRandomLocation = new GoToRandomLocation(this);
    // this.commands.Add(this.GoToRandomLocation);

    // this.commands.Add(new Greet(this.controller));
    // this.commands.Add(new WalkForward(this.controller));
  }

  private void EnqueueCommand () {
    activeCommands.Enqueue(this.RandomCommand());
    activeCommands.Enqueue(this.Wait);
  }

  public ICommand RandomCommand () {
    int randomIndex = this.RandomCommandIndex();
    return this.commands[randomIndex];
  }

  private int RandomCommandIndex () {
    return (int)Mathf.Round(Random.value * (this.commands.Count - 1));
  }

  private void ExecutionCallback () {
    Debug.Log("Execution Callback");
    this.idle = true;
    this.activeCommands.Dequeue();
  }
}
using UnityEngine;
using System;
using System.Collections;

public class Interact : Command, ICommand {
  public Vector3 location;
  private ICommander commander;

  public Interact () : base () {}

  public Interact (ICommander commander) {
    this.commander = commander;
  }

  public IEnumerator Execute (Action done) {
    this.isComplete = false;

    // while (!isComplete) {
    //   StartCoroutine(RandomCommand(ExecutionCallback));
      yield return null;
    // }

    done();
  }

  private ICommand RandomCommand () {
    return this.commander.Commands.RandomItem();
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }
}
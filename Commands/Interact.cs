using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Interact : Command, ICommand {
  public Vector3 location;
  private Commander commander;
  private List<ICommand> interactions;

  public Interact () : base () {}

  public Interact (Commander commander, List<ICommand> interactions) {
    this.commander = commander;
    this.interactions = interactions;
  }

  public IEnumerator Execute (Action done) {
    commander.Execute(RandomCommand(), ExecutionCallback);
    yield return null;

    done();
  }

  private ICommand RandomCommand () {
    int randomIndex = RandomInteractionIndex();
    return interactions[randomIndex];
  }

  private int RandomInteractionIndex () {
    return (int)Mathf.Round(UnityEngine.Random.value * (this.interactions.Count - 1));
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }
}
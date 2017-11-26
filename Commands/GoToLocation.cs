using UnityEngine;
using System;
using System.Collections;

public class GoToLocation : Command, ICommand {
  public Vector3 location;

  public GoToLocation () : base () {}

  public GoToLocation (Commander commander) : base(commander) {
    this.location = new Vector3(10, 0, 0);
  }

  public IEnumerator Execute (Action callback) {
    while(!this.isComplete) {
      Debug.Log("walking");
      this.commander.controller.Face(this.location);
      this.commander.controller.WalkForward();
      TryStopping();
      yield return null;
    }

    callback();
  }

  private void TryStopping () {
    float distance = Vector3.Distance(this.location, this.commander.autonomy.senses.Location);
    if (distance < 0.5f) {
      this.isComplete = true;
    }
    Debug.Log("distance: " + distance);
  }
}
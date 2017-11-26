using UnityEngine;
using System;
using System.Collections;

public class GoToLocation : Command, ICommand {
  private bool isComplete = false;
  public Vector3 location;

  public GoToLocation () : base () {}

  public GoToLocation (Commander commander) : base(commander) {
    this.location = new Vector3(10, 0, 0);
  }

  public IEnumerator Execute (Action callback) {
    this.isComplete = false;

    while(!this.isComplete) {
      TryStopping();
      Debug.Log("walking");
      this.commander.controller.Face(this.location);
      this.commander.controller.WalkForward();
      yield return null;
    }

    callback();
  }

  private void TryStopping () {
    Debug.Log("Trying to Stop");
    float distance = Vector3.Distance(this.location, this.commander.autonomy.senses.Location);
    if (distance < 1f) {
      this.isComplete = true;
    }
    Debug.Log("distance: " + distance);
  }
}
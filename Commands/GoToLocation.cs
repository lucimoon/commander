using UnityEngine;
using System;
using System.Collections;

public class GoToLocation : CharacterCommand, ICommand {
  public Vector3 location;

  public GoToLocation () : base () {}

  public GoToLocation (
    CharacterCommander commander,
    ThirdPersonCtrl controller,
    Sensor sensor)
    : base(commander, controller, sensor) {
    this.location = new Vector3(10, 0, 0);
  }

  public IEnumerator Execute (Action callback) {
    this.isComplete = false;

    while(!this.isComplete) {
      TryStopping();
      this.commander.controller.Face(this.location);
      this.commander.controller.WalkForward();
      yield return null;
    }

    callback();
  }

  private void TryStopping () {
    float distance = Vector3.Distance(this.location, this.sensor.Location);
    if (distance < 1f) {
      this.isComplete = true;
    }
  }
}
using UnityEngine;
using System;
using System.Collections;

public class Stare : CharacterCommand, ICommand {
  public Vector3 location;
  private Wait wait;

  public Stare () : base () {}

  public Stare (
    CharacterCommander commander,
    ThirdPersonCtrl controller,
    Sensor sensor)
    : base(commander, controller, sensor) {
    this.location = new Vector3(10, 0, 0);
    wait = new Wait();
  }

  public IEnumerator Execute (Action unblockCallback) {
    unblockCallback();
    this.location = this.sensor.InterestingObjectLocation;
    this.isComplete = false;

    wait.SetRandomTime();
    this.commander.Execute(this.wait, this.ExecutionCallback);
    while(!this.isComplete) {
      this.commander.controller.LookAt(this.location);
      yield return null;
    }

    this.isComplete = false;
    wait.SetTime(2f);
    this.commander.Execute(this.wait, this.ExecutionCallback);
    while(!this.isComplete) {
      this.commander.controller.LookAhead();
      yield return null;
    }
  }

  private void ExecutionCallback() {
    this.isComplete = true;
  }
}
using UnityEngine;
using System;
using System.Collections;

public class LookAt : CharacterCommand, ICommand {
  public Vector3 location;

  public LookAt () : base () {}

  public LookAt (
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
      this.commander.controller.LookAt(this.location);
      yield return null;
    }

    callback();
  }

  private void TryStopping () {
    Vector3 targetXZ = new Vector3(this.location.x, this.sensor.Location.y, this.location.z);
    float distance = Vector3.Distance(targetXZ, this.sensor.Location);
    if (distance < 1f) {
      this.isComplete = true;
    }
  }
}
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Task: Change Interaction Command to
// Have swappable oBject of Focus

public class ComeToMe : Command, ICommand {
  CharacterCommander commander;
  GoToLocation goToLocation;
  Sensor sensor;
  Wait wait;
  GameObject me;

  public ComeToMe () : base () {}

  public ComeToMe (CharacterCommander commander, Sensor sensor, GameObject me) {
    this.commander = commander;
    this.sensor = sensor;
    this.wait = new Wait();
    this.me = me;
  }

  public IEnumerator Execute (Action done) {
    isComplete = false;

    randomObjectIndex = UnityEngine.Random.Range(0, sensor.SensedObjects.Count);

    wait.SetTime(2f);
    this.commander.Execute(this.wait, this.ExecutionCallback);
    while(!this.isComplete) {
      this.commander.controller.LookAt(me.transform.position);
      yield return null;
    }

    isComplete = false;
    this.commander.GoToLocation.location = otherObject.transform.position;
    this.commander.Execute(commander.GoToLocation, ExecutionCallback);
    while(!isComplete) {
      this.commander.controller.LookAt(me.transform.position);
      yield return null;
    }

    done();
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }
}
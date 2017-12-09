using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Task: Change Interaction Command to
// Have swappable oBject of Focus

public class Interaction : Command, ICommand {
  CharacterCommander commander;
  Sensor sensor;
  Wait wait;

  public Interaction () : base () {}

  public Interaction (CharacterCommander commander, Sensor sensor) {
    this.commander = commander;
    this.sensor = sensor;
    this.wait = new Wait();
  }

  public IEnumerator Execute (Action done) {
    isComplete = false;

    if (sensor.SensedObjects.Count > 0) {
      GameObject otherObject;
      int randomObjectIndex;

      randomObjectIndex = UnityEngine.Random.Range(0, sensor.SensedObjects.Count);
      otherObject = sensor.SensedObjects[randomObjectIndex];

      wait.SetTime(2f);
      this.commander.Execute(this.wait, this.ExecutionCallback);
      while(!this.isComplete) {
        this.commander.controller.LookAt(otherObject.transform.position);
        yield return null;
      }

      isComplete = false;
      this.commander.GoToLocation.location = otherObject.transform.position;
      this.commander.Execute(commander.GoToLocation, ExecutionCallback);
      while(!isComplete) {
        this.commander.controller.LookAt(otherObject.transform.position);
        yield return null;
      }

      isComplete = false;
      commander.Execute(RandomCommand(otherObject), ExecutionCallback);
      while(!isComplete) {
        this.commander.controller.LookAt(otherObject.transform.position);
        yield return null;
      }

      isComplete = false;
      wait.SetTime(2f);
      this.commander.Execute(this.wait, this.ExecutionCallback);
      while(!this.isComplete) {
        this.commander.controller.LookAhead();
        yield return null;
      }
    } else {
      this.commander.Execute(commander.GoToRandomLocation, ExecutionCallback);

      while(!isComplete) {
        yield return null;
      }
    }

    done();
  }

  private ICommand RandomCommand (GameObject otherObject) {
    IInteractable otherCommander = (IInteractable)otherObject.GetComponent<Commander>();
    int randomIndex = RandomInteractionIndex(otherCommander.Interactions);
    return otherCommander.Interactions[randomIndex];
  }

  private int RandomInteractionIndex (List<ICommand> interactions) {
    return (int)Mathf.Round(UnityEngine.Random.value * (interactions.Count - 1));
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }
}
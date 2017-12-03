using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Task: Change Interaction Command to
// Have swappable oBject of Focus

public class Interaction : Command, ICommand {
  CharacterCommander commander;
  Sensor sensor;

  public Interaction () : base () {}

  public Interaction (CharacterCommander commander, Sensor sensor) {
    this.commander = commander;
    this.sensor = sensor;
  }

  public IEnumerator Execute (Action done) {
    isComplete = false;

    if (sensor.SensedObjects.Count > 0) {
      int randomObjectIndex = UnityEngine.Random.Range(0, sensor.SensedObjects.Count);
      GameObject otherObject = sensor.SensedObjects[randomObjectIndex];
      this.commander.GoToLocation.location = otherObject.transform.position;
      this.commander.Execute(commander.GoToLocation, ExecutionCallback);

      while(!isComplete) {
        yield return null;
      }

      isComplete = false;
      commander.Execute(RandomCommand(otherObject), ExecutionCallback);

      while(!isComplete) {
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
using System;
using System.Collections;
using UnityEngine;

public class GoToRandomLocation : CharacterMacroCommand, ICommand {
  private float maxDistance = 10f;
  private Vector3 location;
  private Sensor sensor;

  public GoToRandomLocation (CharacterCommander commander, Sensor sensor) : base(commander) {
    this.sensor = sensor;
  }

  public IEnumerator Execute (Action callback) {
    if (this.commander == null) {
      Debug.Log("Missing Commander ===================================");
      callback();
    } else {
      this.isComplete = false;
      this.location = this.SelectRandomLocation();
      Debug.Log(this.location);
      // Set Location 
      this.commander.GoToLocation.location = location;
      this.commander.Execute(commander.GoToLocation, ExecutionCallback);

      while(!this.isComplete) {
        yield return null;
      }

      callback();
    }
  }

  private Vector3 SelectRandomLocation () {
    Vector3 randomDistance = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance), 0.0f, UnityEngine.Random.Range(-maxDistance, maxDistance));
    return this.sensor.Location + randomDistance;
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }

}
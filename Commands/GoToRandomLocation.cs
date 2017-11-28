using System;
using System.Collections;
using UnityEngine;

public class GoToRandomLocation : CharacterMacroCommand, ICommand {
  private float maxDistance = 30f;
  private Vector3 location;
  public Senses senses;

  public GoToRandomLocation (CharacterCommander commander) : base(commander) {}

  public IEnumerator Execute (Action callback) {
    if (this.commander == null) {
      Debug.Log("Missing Commander ===================================");
      callback();
    } else {
      this.isComplete = false;
      this.location = this.SelectRandomLocation();

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
    return new Vector3(UnityEngine.Random.Range(-1, 1), 0.0f, UnityEngine.Random.Range(-1, 1)) * maxDistance;
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }

  private void TryStopping () {
    float distance = Vector3.Distance(this.location, this.senses.Location);
    if (distance < 0.5f) {
      this.isComplete = true;
    }
  }
}
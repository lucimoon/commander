using UnityEngine;
using System;
using System.Collections;

public class GoToRandomLocation : MacroCommand, ICommand {
  private float maxDistance = 30f;
  private Vector3 location;
  public Commander commander;

  void Start () {
  }

  public IEnumerator Execute (Action callback) {
    if (this.commander == null) {
      Debug.Log("Missing Commander ===================================");
      callback();
    } else {
      this.isComplete = false;
      this.location = this.SelectRandomLocation();

      // Set Location 
      this.commander.GoToLocation.location = location;
      StartCoroutine(this.commander.GoToLocation.Execute(ExecutionCallback));

      while(!this.isComplete) {
        yield return null;
      }

      callback();
    }
  }

  private Vector3 SelectRandomLocation () {
    Vector3 randomLocation = new Vector3(UnityEngine.Random.Range(-1, 1), 0.0f, UnityEngine.Random.Range(-1, 1)) * maxDistance;
    Debug.Log("randomLocation: " + randomLocation);

    return randomLocation;
  }

  private void ExecutionCallback () {
    this.isComplete = true;
  }

  private void TryStopping () {
    float distance = Vector3.Distance(this.location, this.commander.autonomy.senses.Location);
    if (distance < 0.5f) {
      this.isComplete = true;
    }
  }
}
using UnityEngine;
using System;
using System.Collections;

public class GoToRandomLocation : Command, ICommand {
  private float maxDistance = 30f;
  private Vector3 location;

  public GoToRandomLocation () : base () {}

  public GoToRandomLocation (ThirdPersonCtrl controller) : base (controller) {
    Debug.Log("WARNING: GoToRandomLocation requires commander instance");
  }

  public GoToRandomLocation(Commander commander) : base(commander) {
    this.location = this.SelectRandomLocation();
  }

  public IEnumerator Execute (Action callback) {
    while(!this.isComplete) {
      this.commander.GoToLocation.location = location;
      Debug.Log(this.commander.GoToLocation.location);

      TryStopping();
      yield return null;
    }

    callback();
  }

  private Vector3 SelectRandomLocation () {
    return new Vector3(UnityEngine.Random.Range(-1, 1), 0.0f, UnityEngine.Random.Range(-1, 1)) * maxDistance;
  }

  private void TryStopping () {
    float distance = Vector3.Distance(this.location, this.commander.autonomy.senses.Location);
    if (distance < 0.5f) {
      this.isComplete = true;
    }
  }
}
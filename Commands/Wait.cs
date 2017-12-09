using UnityEngine;
using System;
using System.Collections;

public class Wait : Command, ICommand {
  private float waitTime = 0f;
  private float minTimeInclusive = 1f;
  private float maxTimeInclusive = 2f;

  public Wait () : base () {}

  public IEnumerator Execute (Action callback) {
    yield return new WaitForSeconds(waitTime);
    callback();
  }

  public void SetRandomTime() {
    waitTime = UnityEngine.Random.Range(minTimeInclusive, maxTimeInclusive);
  }

  public void SetTime(float seconds) {
    waitTime = seconds;
  }
}

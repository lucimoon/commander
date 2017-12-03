using UnityEngine;
using System;
using System.Collections;

public class Wait : Command, ICommand {
  private float waitTime = 0f;
  private float minTimeInclusive = 0f;
  private float maxTimeInclusive = 5f;

  public Wait () : base () {}

  public IEnumerator Execute (Action callback) {
    SetWaitTime();
    yield return new WaitForSeconds(waitTime);
    callback();
  }

  private void SetWaitTime() {
    waitTime = UnityEngine.Random.Range(minTimeInclusive, maxTimeInclusive);
  }
}

using UnityEngine;
using System.Collections;

public class Command {
  protected bool isComplete = false;
  protected bool executing = false;

  public bool IsComplete {
    get {
      return this.isComplete;
    }
  }
}
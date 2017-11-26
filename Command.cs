using UnityEngine;
using System.Collections;

public class Command {
  protected ThirdPersonCtrl controller;
  protected Commander commander;
  protected bool isComplete = false;
  protected bool executing = false;

  public Command () {
    Debug.Log("WARNING: Missing Player Controller. Initialize with controller.");
  }

  public Command (ThirdPersonCtrl controller) {
    this.controller = controller;
  }

  public Command (Commander commander) {
    this.commander = commander;
  }

  public Command (ThirdPersonCtrl controller, Commander commander) {
    this.controller = controller;
    this.commander = commander;
  }

  public bool IsComplete {
    get {
      return this.isComplete;
    }
  }
}
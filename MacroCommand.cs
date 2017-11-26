using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroCommand : MonoBehaviour, ICommand {
  private List<Command> commands;
  protected bool isComplete = false;

  void Start () {
    commands = new List<Command>();
  }

  void Update() {

  }

  public IEnumerator Execute (Action callback) {
    yield return null;
    callback();
  }
}
using UnityEngine;
using System;
using System.Collections;

public class Greet : CharacterCommand, ICommand {
  public Greet () : base() {}

  public Greet (ThirdPersonCtrl controller) : base(controller) {}

  public IEnumerator Execute (Action callback) {
    Debug.Log("Executing Greet");
    this.controller.Greet();
    callback();
    yield return null;
  }
}
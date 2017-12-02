using UnityEngine;
using System;
using System.Collections;

class ChangeColor : Command, ICommand {
  private BoxController controller;

  public ChangeColor (BoxController controller) {
    this.controller = controller;
  }

  public IEnumerator Execute (Action done) {
    this.controller.ChangeColor();
    yield return new WaitForSeconds(1f);
    done();
  }
}
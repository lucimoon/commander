using UnityEngine;
using System;
using System.Collections;

class ChangeSize : Command, ICommand {
  private BoxController controller;

  public ChangeSize (BoxController controller) {
    this.controller = controller;
  }

  public IEnumerator Execute (Action done) {
    this.controller.ChangeSize();
    yield return new WaitForSeconds(1f);
    done();
  }
}
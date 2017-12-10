using UnityEngine;
using System;
using System.Collections;

class ChangeSizeColor : Command, ICommand {
  private BoxController controller;

  public ChangeSizeColor (BoxController controller) {
    this.controller = controller;
  }

  public IEnumerator Execute (Action done) {
    this.controller.ChangeSizeColor();
    yield return new WaitForSeconds(1f);
    done();
  }
}
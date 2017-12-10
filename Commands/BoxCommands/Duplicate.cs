using UnityEngine;
using System;
using System.Collections;

class Duplicate : Command, ICommand {
  private BoxController controller;

  public Duplicate (BoxController controller) {
    this.controller = controller;
  }

  public IEnumerator Execute (Action done) {
    this.controller.Duplicate();
    yield return new WaitForSeconds(1f);
    done();
  }
}
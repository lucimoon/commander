using UnityEngine;
using System;
using System.Collections;

public interface ICommand {
  IEnumerator Execute(Action callback);
}
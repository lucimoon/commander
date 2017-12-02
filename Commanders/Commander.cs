using UnityEngine;

public class Commander : MonoBehaviour {
  public void Execute (ICommand command, System.Action callback) {
    StartCoroutine(command.Execute(callback));
  }
}
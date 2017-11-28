using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autonomy : MonoBehaviour {
  private float timeLeft = 0f;
  private bool ready = false;
  private ICommand currentCommand;
  private ICommander commander;
  public Senses senses;

  void Start () {
    this.senses = new Senses(gameObject);
    this.commander = gameObject.AddComponent<CharacterCommander>() as ICommander;
  }
}
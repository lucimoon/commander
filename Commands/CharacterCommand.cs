using UnityEngine;
using System.Collections;

public class CharacterCommand : Command {
  protected ThirdPersonCtrl controller;
  protected CharacterCommander commander;
  protected Senses senses;

  public CharacterCommand () : base () {}

  public CharacterCommand (
    CharacterCommander commander) {
    this.commander = commander;
  }

  public CharacterCommand (
    ThirdPersonCtrl controller) {
    this.controller = controller;
  }

  public CharacterCommand (
    CharacterCommander commander,
    ThirdPersonCtrl controller) {
    this.controller = controller;
    this.commander = commander;
  }

  public CharacterCommand (
    CharacterCommander commander,
    ThirdPersonCtrl controller,
    Senses senses) {
    this.controller = controller;
    this.commander = commander;
    this.senses = senses;
  }
}
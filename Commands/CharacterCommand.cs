using UnityEngine;
using System.Collections;

public class CharacterCommand : Command {
  protected ThirdPersonCtrl controller;
  protected CharacterCommander commander;
  protected Sensor sensor;

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
    Sensor sensor) {
    this.controller = controller;
    this.commander = commander;
    this.sensor = sensor;
  }
}
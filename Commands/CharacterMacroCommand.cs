using UnityEngine;

public class CharacterMacroCommand : MacroCommand {
  protected CharacterCommander commander;

  public CharacterMacroCommand (CharacterCommander commander) {
    this.commander = commander;
  }
}
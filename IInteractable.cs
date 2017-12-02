using System.Collections.Generic;

public interface IInteractable {
  List<ICommand> Interactions {
    get;
  }

  ICommand RandomInteraction ();
}
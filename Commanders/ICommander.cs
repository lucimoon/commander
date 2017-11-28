using UnityEngine;
using System.Collections.Generic;

public interface ICommander {
  List<ICommand> Commands {
    get;
  }
}
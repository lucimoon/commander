using UnityEngine;
using System.Collections.Generic;

public interface ICommander {
  MultiList<ICommand> Commands {
    get;
  }
}
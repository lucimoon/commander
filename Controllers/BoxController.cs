using UnityEngine;

public class BoxController : MonoBehaviour {
  public void ChangeColor () {
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.SetColor("_Color", Color.red);
  }

  void Start () {
    ChangeColor();
  }
}
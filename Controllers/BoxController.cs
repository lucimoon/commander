using UnityEngine;

public class BoxController : MonoBehaviour {
  public void ChangeColor () {
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f));
  }
}
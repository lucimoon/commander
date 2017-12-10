using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ItemSpawner))]
public class BoxController : MonoBehaviour {
  ItemSpawner spawner;

  void Start() {
    spawner = GetComponent<ItemSpawner>();
  }

  public void ChangeColor () {
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f));
  }

  public void ChangeSize () {
    gameObject.transform.localScale *= Random.Range(0.5f, 2f);
  }

  public void ChangeSizeColor () {
    this.ChangeSize();
    this.ChangeColor();
  }

  public void Duplicate() {
    if (spawner != null) {
      spawner.SpawnSingle();
    }
  }
}
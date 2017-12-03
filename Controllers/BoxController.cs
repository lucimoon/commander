using UnityEngine;
using System.Collections.Generic;

public class BoxController : MonoBehaviour {
  public void ChangeColor () {
    Renderer renderer = GetComponent<Renderer>();
    renderer.material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f));
  }

  public void ChangeSize () {
    List<int> positiveOrNegativeOpts = new List<int>(new int[] {-1, 1});
    int positiveOrNegative = positiveOrNegativeOpts[Random.Range(0,  positiveOrNegativeOpts.Count)];
    float relativeChange = Random.value;
    float totalChange = relativeChange * positiveOrNegative;
    gameObject.transform.localScale += new Vector3(totalChange, totalChange, totalChange);
  }
}
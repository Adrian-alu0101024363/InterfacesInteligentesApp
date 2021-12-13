using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
  private Color color;
  public GameObject cubeItem;
  private Renderer cubeRenderer;
    // Start is called before the first frame update
    void Start()
    {
        cubeRenderer = cubeItem.GetComponent<Renderer>();
        controladorjuego.color_change += change;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void change(string dir) {
      if (dir == "N") {
        color = new Color(0f,0f,42f);
      } else if (dir == "S") {
        color = new Color(0f,45f,0f);
      } else if (dir == "E") {
        color = new Color(10f,10f,10f);
      } else {
        color = new Color(0f,15f,42f);
      }
      cubeRenderer.material.SetColor("_Color", color);
    }
}

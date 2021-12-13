using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
  //public Transform playerTransform;
  public Text status;
  Vector3 dir;
    void execute() {
      InvokeRepeating("UpdateCompassData", 0.5f, 1f);
    }
    void UpdateCompassData() {
      float actual;
      float north = 50f;
        if (Input.compass.enabled) {
          status.text = Input.compass.trueHeading.ToString();
          actual = Input.compass.trueHeading;
          if (actual < north) {
            controladorjuego.color_change("N");
          } else if (actual > 200f) {
            controladorjuego.color_change("S");
          } else {
            controladorjuego.color_change("E");
          }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine("execute");
    }

    // Update is called once per frame
    void Update()
    {
        //dir.z = playerTransform.eulerAngles.y;
        //transform.localEulerAngles = dir;
    }
}

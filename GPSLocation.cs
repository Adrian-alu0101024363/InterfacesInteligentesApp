using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
public class GPSLocation : MonoBehaviour
{
  //public Text GPSStatus;
  public Text latitudValue;
  public Text longitudValue;
  //public Text altitudeValue;
  //public Text horizontalAccuracyValue;
  //public Text timestampValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GPSLoc());
    }
    private void Awake() {
      if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)) {
        Permission.RequestUserPermission(Permission.FineLocation);
      }
    }
    IEnumerator GPSLoc() {
      if (!Input.location.isEnabledByUser) {
        yield break;
      }
      Input.compass.enabled = true;
      Input.location.Start();
      int maxWait = 20;
      while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
        yield return new WaitForSeconds(1);
        maxWait--;
      }
      if (maxWait < 1) {
        //GPSStatus.text = "Time out";
        yield break;
      }
      if (Input.location.status == LocationServiceStatus.Failed) {
        //GPSStatus.text = "Unable to determine device location";
        yield break;
      } 
        //Todo ok
        //GPSStatus.text = "Running";
        // Por cada segundo 1f
        latitudValue.text = "0";
        longitudValue.text = "0";
        InvokeRepeating("UpdateGPSData", 0.5f, 1f);
    }
    private void UpdateGPSData() {
      if (Input.location.status == LocationServiceStatus.Running) {
        //GPSStatus.text = "Running";
        latitudValue.text = Input.location.lastData.latitude.ToString();
        longitudValue.text = Input.location.lastData.longitude.ToString();
        //altitudeValue.text = Input.location.lastData.altitude.ToString();
        //horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
        //timestampValue.text = Input.location.lastData.timestamp.ToString();           
      } else {
        //GPSStatus.text = "Stopped";
        latitudValue.text = "0";
        longitudValue.text = "0";
      }
    }
    // Update is called once per frame
    void Update()
    {
        //UpdateGPSData();
    }
}

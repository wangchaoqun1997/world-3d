using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint : MonoBehaviour {

    public Color PaintColor = Color.red;
    public float PaintSize = 0.1f;
    private LineRenderer AnLineRenderer;
    private Vector3 MousePositionOld = new Vector3(0.0f,0.0f,0.0f);
    private int NumOfLineRenderer = 0;
    #region
    public void OnValueChangedRed(bool isOn) {
        if (isOn) {
            PaintColor = Color.red;
        }
    }
    public void OnValueChangedGreen(bool isOn)
    {
        if (isOn)
        {
            PaintColor = Color.green;
        }
    }
    public void OnValueChangedBlue(bool isOn)
    {
        if (isOn)
        {
            PaintColor = Color.blue;
        }
    }
    public void OnValueChangedSize01(bool isOn)
    {
        if (isOn)
        {
            PaintSize = 0.1f;
        }
    }

    public void OnValueChangedSize02(bool isOn)
    {
        if (isOn)
        {
            PaintSize = 0.2f;
        }
    }
    public void OnValueChangedSize04(bool isOn)
    {
        if (isOn)
        {
            PaintSize = 0.4f;
        }
    }

    #endregion

    void Update() {

            //create linerenderer with size and color
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = new GameObject();
            obj.transform.parent = gameObject.transform;
            AnLineRenderer = obj.AddComponent<LineRenderer>();
            AnLineRenderer.positionCount = 0;
            AnLineRenderer.material.color = PaintColor;
            AnLineRenderer.startWidth = PaintSize;
            AnLineRenderer.endWidth = PaintSize;
            AnLineRenderer.numCornerVertices = 5;
            AnLineRenderer.numCapVertices = 5;
            NumOfLineRenderer += 1;
            //AnLineRenderer.startColor = PaintColor;
            //AnLineRenderer.endColor = PaintColor;
        }
        if (AnLineRenderer != null)
        {
            if (Vector3.Distance(Input.mousePosition, MousePositionOld) > 0.02f)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.DrawRay(ray.origin, hit.point, Color.blue);
                    AnLineRenderer.positionCount += 1;
                    AnLineRenderer.SetPosition(AnLineRenderer.positionCount - 1, hit.point+new Vector3(0,0,-0.02f * NumOfLineRenderer));
                    Debug.Log(hit.point);
                }
            }
        }
        MousePositionOld = Input.mousePosition;
        
        if (Input.GetMouseButtonUp(0))
        {
            //end the linerenderer
            AnLineRenderer = null;
        }
    }
    void Start() {
        
    }
}

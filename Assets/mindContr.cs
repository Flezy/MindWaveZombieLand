using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mindContr : MonoBehaviour {
    public Light dirLight;
    public EnemyManager em;
    public CameraController cc;

    private int _poorSignal;
    private float attention1;
    private float meditation1;
    private float _delta;

    private TGCConnectionController controller;
    void Start()
    {
        
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        if (controller == null)
        {
           Debug.Log("neuroskycontroller not found");
        }
        
        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        controller.UpdateAttentionEvent += OnUpdateAttention;
        controller.UpdateMeditationEvent += OnUpdateMeditation;
        controller.UpdateDeltaEvent += OnUpdateDelta;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("space"))
        {
            controller.Connect();
        }
    }
    void OnUpdateAttention(int value)
    {
        attention1 = value;
        em.sendAttention(value);
        cc.setMoveSpeed(10);
    }
    void OnUpdateMeditation(int value)
    {
        meditation1 = value;
        dirLight.intensity = (float)value / (float)100;
    }
    void OnUpdatePoorSignal(int value)
    {

    }
    void OnUpdateDelta(float value)
    {

    }
}

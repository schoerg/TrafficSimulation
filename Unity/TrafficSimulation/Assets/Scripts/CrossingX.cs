﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingX : MonoBehaviour {

    public GameObject posX ;
    public GameObject negX ;
    public GameObject posY ;
    public GameObject negY ;

    public bool isControlledByTrafficLight=true;
    private string uuid;

    // Use this for initialization
    void Start () {

    }


    private void Awake()
    {
        if (!isControlledByTrafficLight)
        {
            Destroy(getChildGameObject(gameObject, "TrafficLights"));
            uuid = "";
        }
        else
        {
            uuid = System.Guid.NewGuid().ToString();
            uuid = System.Guid.NewGuid().ToString();
            Simulation.getInstance().createNewTrafficLight(uuid, "PosY", "NegY", "PosX", "NegX");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void setCollider(string id, CrossingColliderX coll)
    {
        switch (id)
        {
            case "NegX":
                coll.setDirectionsIntern(getChildGameObject(gameObject, "PathPosX"), negY, posX, posY, isControlledByTrafficLight, uuid);
                break;
            case "PosX":
                coll.setDirectionsIntern(getChildGameObject(gameObject, "PathNegX"), posY, negX, negY, isControlledByTrafficLight,uuid);
                break;
            case "NegY":
                coll.setDirectionsIntern(getChildGameObject(gameObject, "PathPosY"), posX, posY, negX, isControlledByTrafficLight,uuid);
                break;
            case "PosY":
                coll.setDirectionsIntern(getChildGameObject(gameObject, "PathNegY"), negX, negY, posX, isControlledByTrafficLight,uuid);
                break;
        }

    }

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}

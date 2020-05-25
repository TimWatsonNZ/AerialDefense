using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {

    public Transform grassPrefab;
	// Use this for initialization
	void Start () {

        float width = Camera.main.orthographicSize * Camera.main.aspect;
        float height = Camera.main.orthographicSize;

        for (float w = -width; w < width; w+=1)
        {
            Instantiate(grassPrefab, new Vector3(w + 0.5f, -height + 0.5f, 0), Quaternion.identity);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

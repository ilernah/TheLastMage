using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject player;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        player.transform.position = new Vector3(8, -1, 0);

        //Set object as already initiated object, not prefab;
        player = Instantiate(player);

        CameraFollow script = Camera.main.GetComponent<CameraFollow>();
        script.targetTransform = player.transform;        
    }	
}

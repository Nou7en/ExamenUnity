using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComida : MonoBehaviour
{
    public GameObject comidaPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector3 randomPosition = new Vector3(Random.Range(-40, 40),1.72f, 0);
            Instantiate(comidaPrefab, randomPosition,Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter(Collider other) {
       
    }
}

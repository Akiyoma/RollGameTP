using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour {
    public GridManager gridManager;
    public GameManager gameManager;
    
    public List<Vector3> previousPos;
    
    private void OnCollisionEnter(Collision collision) {
        Vector3 normal = collision.contacts[0].normal;

        Vector3 pos = transform.position;
        
        if (Mathf.Abs(normal.x) >= 1 && pos.x + normal.x >= 0 && pos.x + normal.x < gridManager.gridSize.x) {
            if (!gridManager.blockedTiles[(int)(pos.x + normal.x), (int)pos.z]) {
                gameManager.AddPreviousPos(this, new Vector3(-normal.x, 0f, 0f));
                transform.position += new Vector3(normal.x, 0f, 0f);
            }
        }
        else if (Mathf.Abs(normal.z) >= 1 && pos.z + normal.z >= 0 && pos.z + normal.z < gridManager.gridSize.y) {
            if (!gridManager.blockedTiles[(int)pos.x, (int)(pos.z + normal.z)]) {
                gameManager.AddPreviousPos(this, new Vector3(0f, 0f, -normal.z));
                transform.position += new Vector3(0f, 0f, normal.z);
            }
        }
    }
}

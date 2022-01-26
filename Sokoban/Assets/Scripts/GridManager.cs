using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public Transform tilePrefab;
    public Transform wallPrefab;
    
    public Vector2 gridSize;
    
    public bool[,] blockedTiles;

    private void Start() {
        GenerateGrid();
    }

    public void GenerateGrid() {
        blockedTiles = new bool[(int)gridSize.x, (int)gridSize.y];
        
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                blockedTiles[x, y] = false;
            }
        }
        
        Transform blockedTilesTransform = transform.Find("Blocked Tiles");
        foreach (Transform child in blockedTilesTransform) {
            int x = (int)child.transform.position.x;
            int y = (int)child.transform.position.z;
            blockedTiles[x, y] = true;
        }

        float tileScaleX = tilePrefab.localScale.x;
        float tileScaleY = tilePrefab.localScale.z;

        if (transform.Find("GridGenerated")) {
            DestroyImmediate(transform.Find("GridGenerated").gameObject);
        }

        Transform gridGenerated = new GameObject("GridGenerated").transform;
        gridGenerated.parent = transform;
        
        Transform tilesTransform = new GameObject("Tiles").transform;
        tilesTransform.parent = gridGenerated;
        
        Transform wallsTransform = new GameObject("Walls").transform;
        wallsTransform.parent = gridGenerated;
        
        for (int x = 0; x < gridSize.x; x++) {
            for (int y = 0; y < gridSize.y; y++) {
                Vector3 tilePosition = new Vector3(x * tileScaleX, 0, y * tileScaleY);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, tilesTransform);
            }
        }
        
        // Walls
        Vector3 wallPrefabScale = wallPrefab.localScale;
        
        Vector3 wallLeftPosition = new Vector3(-tileScaleX, 1, (gridSize.y - 1)/2);
        Transform wallLeft = Instantiate(wallPrefab, wallLeftPosition, Quaternion.identity, wallsTransform);
        wallLeft.localScale = new Vector3(wallPrefabScale.x, wallPrefabScale.y, wallPrefabScale.z * gridSize.y + 2);
        
        Vector3 wallRightPosition = new Vector3(gridSize.x * tileScaleX, 1, (gridSize.y - 1)/2);
        Transform wallRight = Instantiate(wallPrefab, wallRightPosition, Quaternion.identity, wallsTransform);
        wallRight.localScale = new Vector3(wallPrefabScale.x, wallPrefabScale.y, wallPrefabScale.z * gridSize.y + 2);
        
        Vector3 wallUpPosition = new Vector3((gridSize.x - 1)/2, 1, gridSize.y * tileScaleY);
        Transform wallUp = Instantiate(wallPrefab, wallUpPosition, Quaternion.identity, wallsTransform);
        wallUp.localScale = new Vector3(wallPrefabScale.x * gridSize.x + 2, wallPrefabScale.y, wallPrefabScale.z);
        
        Vector3 wallDownPosition = new Vector3((gridSize.x - 1)/2, 1, -tileScaleY);
        Transform wallDown = Instantiate(wallPrefab, wallDownPosition, Quaternion.identity, wallsTransform);
        wallDown.localScale = new Vector3(wallPrefabScale.x * gridSize.x + 2, wallPrefabScale.y, wallPrefabScale.z);
    }

    public Vector2 GetPosition(Vector3 position) {
        int posX = (int)(position.x);
        int posY = (int)(position.z);
        Debug.Log((int)(position.z));
        Debug.Log((int)(position.z));
        return new Vector2(posX, posY);
    }
}

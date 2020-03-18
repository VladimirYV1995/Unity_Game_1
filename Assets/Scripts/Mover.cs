﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private Terrain _terrain;

    private float _distanceEndTerrain;
    private float _lastPlayerPositionX;
    private float _speedPlayer;

    private void Start()
    {
        _lastPlayerPositionX = _player.position.x;
        _distanceEndTerrain = _terrain.terrainData.size.x - _player.position.x;
    }

    private void Update()
    {
        if (_lastPlayerPositionX != _player.position.x)
        {
            _speedPlayer = Mathf.Abs(_player.position.x - _lastPlayerPositionX) / Time.deltaTime;

            _camera.position = MovingForPlayer( _camera.position, _player.position.x);            
            _terrain.terrainData.size = MovingForPlayer(_terrain.terrainData.size, _player.position.x + _distanceEndTerrain);

            _lastPlayerPositionX = _player.position.x;
        }
    }

    public Vector3 MovingForPlayer(Vector3 startVector, float x)
    {
        Vector3 endPosition = new Vector3(x, startVector.y, startVector.z);       
        return Vector3.Lerp(startVector, endPosition, _speedPlayer);
    }
}

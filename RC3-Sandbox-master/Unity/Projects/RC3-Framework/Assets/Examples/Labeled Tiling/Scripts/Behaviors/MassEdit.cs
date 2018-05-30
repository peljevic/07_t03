using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RC3.Graphs;
using System;

namespace RC3.Unity.Examples.LabeledTiling
{

    public class MassEdit : MonoBehaviour
    {
        [SerializeField] private SharedDigraph _grid;
        List<VertexObject> _vertices;
        private Digraph _graph;

        private void Start()
        {
            _graph = _grid.Graph;
            _vertices = _grid.VertexObjects;
                     
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.M)) GetMass();
        }

        private void GetMass()
        {
            foreach ( var v in _vertices)
            {
                v.GetComponent<Rigidbody>().mass = v.Tile.Mass;
            }
        }

    }
}
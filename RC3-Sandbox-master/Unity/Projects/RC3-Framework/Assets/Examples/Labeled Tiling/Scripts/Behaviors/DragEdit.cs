using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RC3.Graphs;
using System;

namespace RC3.Unity.Examples.LabeledTiling
{

    public class DragEdit : MonoBehaviour
    {
        [SerializeField] private SharedDigraph _grid;
        [SerializeField] private TileSet _tileSet;
        [SerializeField] private float _speed;
        List<VertexObject> _vertices;
        private Digraph _graph;

        private void Start()
        {
            _graph = _grid.Graph;
            _vertices = _grid.VertexObjects;

        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.D)) GetDrag();

            if (Input.GetKey(KeyCode.M)) CheckMovement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (gameObject.GetComponent<ModelDisplay>() == null)
                {
                    gameObject.AddComponent<ModelDisplay>();
                }
                else
                {
                    Destroy(gameObject.GetComponent<ModelDisplay>());
                }
            }

        }

        private void GetDrag()
        {
            foreach (var v in _vertices)
            {
                v.Body.drag = v.Tile.Mass;
            }
        }

        private void MoveUP()
        {
            if (_speed > 0.05)
            {
                // v.Body.AddRelativeForce(Vector3.up*100);
                //var position = v.transform.position;
                // position += new Vector3(0.5f, 0.5f, 0.5f);

            }
        }

        private void CheckMovement()
        {
            // Time.timeScale = 1;

            for (int i = 0; i < _vertices.Count; i++)
            {

                var v = _vertices[i];
                _speed = v.Velocity;

                if (_speed > 1)
                {
                    Debug.Log("the speed is " + _speed);

                    v.Tile = _tileSet[21];

                    int[] neigh = new int[3];
                    neigh[0] = _graph.GetVertexNeighborOut(i, 3);
                    neigh[1] = _graph.GetVertexNeighborOut(i, 8);
                    neigh[2] = _graph.GetVertexNeighborOut(i, 11);

                    foreach (var n in neigh)
                    {
                        var vn = _vertices[n];
                        var joint = v.gameObject.AddComponent<FixedJoint>();
                        joint.connectedBody = vn.GetComponent<Rigidbody>();

                    }
                }

            }
            //{
            //    if (v.Tile.Mass > 0.2)
            //    {
            //        v.Tile = _tileSet[_tileSet.Count];
            //        v.Tile.Material = v.Tile.MaterialChange;
            //    }

            //    else
            //        v.Body.AddRelativeForce(Vector3.up * 100);
            //var position = v.transform.position;
            // position += new Vector3(0.5f, 0.5f, 0.5f);

        }
    }


            }

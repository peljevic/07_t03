using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RC3.Graphs;
using System;

namespace RC3.Unity.Examples.LabeledTiling
{
    
    public class RotationAndStuff : MonoBehaviour
    {
        [SerializeField] private SharedDigraph _grid;
        [SerializeField] private TileSet _tileSet;
        [SerializeField] private float _speed;
        List<VertexObject> _vertices;
        private Digraph _graph;
        private bool _rotate = false;

        private void Start()
        {
            _graph = _grid.Graph;
            _vertices = _grid.VertexObjects;

        }

        private void Update()
        {

            if (Input.GetKey(KeyCode.M)) CheckMovement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rotate = !_rotate;
                if (_rotate) RotateView();
            }


        }

        private void RotateView()
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

                if (_speed > 1 && v.Tile != _tileSet[0])
                {
                    Debug.Log("the speed is " + _speed);

                    var vDirections = v.Tile.Labels;
                    int[] neigh = new int[3];

                    if (vDirections[3] == "1" || vDirections[8] == "1" || vDirections[11] == "1")
                    {
                        v.Tile = _tileSet[19];

                       
                        neigh[0] = _graph.GetVertexNeighborOut(i, 3);
                        neigh[1] = _graph.GetVertexNeighborOut(i, 8);
                        neigh[2] = _graph.GetVertexNeighborOut(i, 11);
                    }

                    else if (vDirections[1] == "1" || vDirections[9] == "1" || vDirections[6] == "1")
                    {
                        v.Tile = _tileSet[20];


                        neigh[0] = _graph.GetVertexNeighborOut(i, 1);
                        neigh[1] = _graph.GetVertexNeighborOut(i, 9);
                        neigh[2] = _graph.GetVertexNeighborOut(i, 6);
                    }

                    else if (vDirections[0] == "1"  || vDirections[12] == "1")
                    {
                        v.Tile = _tileSet[21];


                        neigh[0] = _graph.GetVertexNeighborOut(i, 0);
                        neigh[1] = _graph.GetVertexNeighborOut(i, 12);
                        neigh[2] = _graph.GetVertexNeighborOut(i, 11);
                    }

                    else if (vDirections[2] == "1" || vDirections[7] == "1" || vDirections[10] == "1")
                    {
                        v.Tile = _tileSet[21];


                        neigh[0] = _graph.GetVertexNeighborOut(i, 2);
                        neigh[1] = _graph.GetVertexNeighborOut(i, 7);
                        neigh[2] = _graph.GetVertexNeighborOut(i, 10);
                    }


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

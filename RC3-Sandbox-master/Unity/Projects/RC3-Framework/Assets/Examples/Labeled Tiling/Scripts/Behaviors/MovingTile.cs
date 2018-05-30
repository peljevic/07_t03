using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RC3.Graphs;
using System;

namespace RC3.Unity.Examples.LabeledTiling
{
    public class MovingTile : MonoBehaviour
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
            if (Input.GetKey(KeyCode.S)) CheckMass();
        }

        private void CheckMass()
        {
            foreach (var v in _vertices )
            {
                if (v.Body.drag > 0 && v.Body != null) Debug.Log("Force on the " + v.Body.drag);
            }
        }



        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Object in front" + gameObject.transform.name);
        }

        void OnMouseDown()
        {
           // Destroy(this.transform.gameObject);
        }


        private void SelectObject()
        {
            RaycastHit objectInFront;

            Vector3 castedRayDirection = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, castedRayDirection, out objectInFront))
            {
                string objectInFrontName = objectInFront.transform.name;
                Debug.Log("There is an object in front of me! It's name is" + objectInFrontName);
              //  Destroy(objectInFront.transform.gameObject);

            }

        }
    }
}


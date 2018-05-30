using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Notes
 */
 
namespace RC3.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class VertexObject : MonoBehaviour
    {
        [SerializeField] private int _vertex;

        [SerializeField] private Vector3 _pos;

        private void Awake()
        {
            _pos = GetComponent<Transform>().position;
        }

        public Vector3 Pos
        {
            get { return _pos; }
        }

        /// <summary>
        /// Returns the vertex associated with this object.
        /// </summary>
        public int Vertex
        {
            get { return _vertex; }
            set { _vertex = value; }
        }
    }
}
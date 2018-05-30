
/*
 * Notes
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace RC3.Unity.Examples.LabeledTiling
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Examples/Labeled Tiling/Tile")]
    public class Tile : ScriptableObject
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;
        [SerializeField, HideInInspector] private string[] _labels;

        [SerializeField] private float _mass;
        [SerializeField] private float _drag;


        public float Mass
        {
            get { return _mass; }
        }


        public float Drag
        {
            get { return _drag; }
        }


        /// <summary>
        /// 
        /// </summary>
        public Mesh Mesh
        {
            get { return _mesh; }
        }


        /// <summary>
        /// 
        /// </summary>
        public Material Material
        {
            get { return _material; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string[] Labels
        {
            get { return _labels; }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RC3.Graphs;
using System;

namespace RC3.Unity.Examples.LabeledTiling
{
    public class EvaluationCriteria : MonoBehaviour
    {
        private float _fitness; //result of all criterias

        //criterias
        private float _connectivity; // able to connect to different tiles from the set
        private float _stability; // speed of the rigidbody is lower than the rest
        private float _adaptivity; // can receive different programs
        private float _openness; // doesn't create the necessary enclosures - troubles with pressure etc 
        


        private void CalculateTileValue()
        {
            _fitness = _stability * 0.4f + _adaptivity * 0.25f + _connectivity * 0.2f - _openness*0.1f;
        }
       
    }
}

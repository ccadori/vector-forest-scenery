using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorForestScenery
{
    public class Scenery : MonoBehaviour
    {
        public List<SceneryItem> Items { get; private set; }

        private void Awake()
        {
            Items = new List<SceneryItem>(GetComponentsInChildren<SceneryItem>());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorForestScenery.Utils
{
    public class Wind : MonoBehaviour
    {
        private SceneryItem[] trees;

        public void Start()
        {
            trees = GameObject.FindObjectsOfType<SceneryItem>();
            InvokeRepeating("WindLeft", 0, 4);
        }

        public void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(00))
            {
                WindLeft();
            }
            else if (Input.GetMouseButtonDown(01))
            {
                WindRight();
            }
        }

        public void WindLeft()
        {
            StartCoroutine(WindTrees((SceneryItem tree) => tree.WindLeft()));
        }

        public void WindRight()
        {
            StartCoroutine(WindTrees((SceneryItem tree) => tree.WindRight()));
        }

        public IEnumerator WindTrees(Action<SceneryItem> action)
        {
            float currentTime = 13;

            List<SceneryItem> alreadyWind = new List<SceneryItem>();
            while (alreadyWind.Count != trees.Length)
            {
                currentTime -= (Time.fixedDeltaTime * 10f);
                yield return new WaitForFixedUpdate();

                foreach (var tree in trees)
                {
                    if (!alreadyWind.Contains(tree) && tree.transform.position.x > currentTime)
                    {
                        action.Invoke(tree);
                        alreadyWind.Add(tree);
                    }
                }
            }
        }
    }
}
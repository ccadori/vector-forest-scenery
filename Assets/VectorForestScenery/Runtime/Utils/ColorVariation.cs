using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorForestScenery.Utils
{
    public class ColorVariation : MonoBehaviour
    {
        #region "Inspector"
        public float _start = -4;
        public float _end = 6;
        public float _maxVariation = 0.8f;
        #endregion

        public void Start()
        {
            SetShadow(GetComponentsInChildren<SceneryItem>());
        }

        public void SetShadow(SceneryItem[] items)
        {
            foreach (var item in items)
            {
                var perc = Mathf.InverseLerp(_start, _end, item.transform.position.y);
                float mult = Mathf.Lerp(0, _maxVariation, perc);
                var color = new Color(1 - mult, 1 - mult, 1 - mult, 1);
                item.SetRendererColor(color);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(new Vector2(0, _start), new Vector2(0, _end));
        }
    }
}

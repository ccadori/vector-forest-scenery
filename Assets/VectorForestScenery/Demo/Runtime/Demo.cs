using UnityEngine;

namespace VectorForestScenery.Demo
{
    public enum InteractionType
    {
        Wind,
        Light,
        Snow
    }

    public class Demo : MonoBehaviour
    {
        #region "Inspector"
        public InteractionType _interaction;
        [Header("Wind")]
        public Utils.Wind _wind;
        public float _windVelocity = 2;
        [Header("Light Variation")]
        public Utils.LightVariation _lightVariation;
        public float _maxLightDistance = 10;
        public float _maxLightVariation = 0.7f;
        [Header("Snow")]
        public Utils.Snow _snow;
        #endregion

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                switch (_interaction)
                {
                    case InteractionType.Wind:
                        {
                            _wind.StartWind(origin, _windVelocity, 30);
                            break;
                        }

                    case InteractionType.Light:
                        {
                            _lightVariation.SetVariation(_maxLightVariation, origin, _maxLightDistance);
                            break;
                        }
                    
                    case InteractionType.Snow:
                        {
                            _snow.SetSnow();
                            break;
                        }
                }
            }
        }
    }
}
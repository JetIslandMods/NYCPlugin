using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using IllusionPlugin;
using UnityEngine;

namespace NYCPlugin
{
    public class Plugin : IPlugin
    {
        int currentLevelId = 0;
        public GameObject nyc;
        public float cityScale = 2f;

        public string Name
        {
            get { return "NYC Plugin"; }
        }
        public string Version
        {
            get { return "0.1"; }
        }

        public void OnApplicationQuit()
        {
        }

        public void OnApplicationStart()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnLevelWasInitialized(int level)
        {
            currentLevelId = level;
            if (currentLevelId == 1)
            {
                AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "newyork.unity3d"));
                GameObject prefab = ab.LoadAsset<GameObject>("NewYorkPrefab");
                nyc = UnityEngine.Object.Instantiate(prefab);
                nyc.transform.position = new Vector3(9636.8f, 3.0f, 7889.3f);
                nyc.transform.localScale = new Vector3(cityScale, cityScale, cityScale);
                ab.Unload(false);
            }
        }

        public void OnLevelWasLoaded(int level)
        {
        }

        public void OnUpdate()
        {
            if (currentLevelId == 1)
            {
                if(Input.GetKeyDown(KeyCode.N))
                {
                    if (cityScale == 1f)
                        cityScale = 2f;
                    else
                        cityScale = 1f;
                    nyc.transform.localScale = new Vector3(cityScale, cityScale, cityScale);
                }
            }
        }
    }
}

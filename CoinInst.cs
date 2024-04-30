using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace CoinRand
{
    public class CoinInst : MonoBehaviour
    {
        public List<Transform> spawnPoints = new List<Transform>();
        [SerializeField] private GameObject coin;
        public HashSet<int> randomValues = new HashSet<int>();
        public Random r = new Random();
        private void Start()
        {
            
            int a = (int)Math.Ceiling(spawnPoints.Count / 2.0f);

            while (randomValues.Count < a)
            {
                randomValues.Add(r.Next(0, spawnPoints.Count - 1));
            }
            //var randomValues = Enumerable.Range(0, a)
            //    .Select(e => spawnPoints[r.Next(spawnPoints.Count)]);
            foreach (var x in randomValues)
            {

                Instantiate(coin, spawnPoints[x]);
            }

        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class PlayerPositionHandler : MonoBehaviour
    {
        private Dictionary<int , DiceEdge> _edgesMap;

        public DiceEdge HighestEdge
        {
            get
            {
                float maxY = -1;
                DiceEdge edge = null;
                foreach (var diceEdge in _edgesMap.Values)
                {
                    if (diceEdge.Position.y > maxY)
                    {
                        edge = diceEdge;
                        maxY = diceEdge.Position.y;
                    }
                }

                if (edge == null)
                    throw new NullReferenceException(nameof(edge));

                return edge;
            }
        }

        private void Awake()
        {
            _edgesMap = new Dictionary<int , DiceEdge>();
            foreach (var edge in GetComponentsInChildren<DiceEdge>())
            {
                _edgesMap[edge.EdgeNumber] = edge;
            }
        }

        public Direction GetDirectionByNumber(int number)
        {
            var edge = _edgesMap[number];

            return Direction.None;
        }
    }
}

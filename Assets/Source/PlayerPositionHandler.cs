using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class PlayerPositionHandler : MonoBehaviour
    {
        private Dictionary<int , DiceEdge> _edgesMap;

        public DiceEdge HighEdge => GetEdgeByCondition((e) => e.Position.y, (e, max) => e > max);
        public DiceEdge LeftEdge => GetEdgeByCondition((e) => e.Position.x, (e, max) => e < max);
        public DiceEdge RightEdge => GetEdgeByCondition((e) => e.Position.x, (e, max) => e > max);
        public DiceEdge ForwardEdge => GetEdgeByCondition((e) => e.Position.z, (e, max) => e > max);
        public DiceEdge BackwardEdge => GetEdgeByCondition((e) => e.Position.z, (e, max) => e < max);

        //Remove on release
        public Dictionary<Direction, int> DirectionsToNumber; 

        private DiceEdge GetEdgeByCondition(Func<DiceEdge, float> getPosition, Func<float, float, bool> condition)
        {
            DiceEdge edge = _edgesMap.Values.First();
            float max = getPosition(edge);
            foreach (var diceEdge in _edgesMap.Values)
            {
                if (condition(getPosition(diceEdge), max))
                {
                    edge = diceEdge;
                    max = getPosition(diceEdge);
                }
            }

            return edge;
        }

        private void Awake()
        {
            _edgesMap = new Dictionary<int , DiceEdge>();
            foreach (var edge in GetComponentsInChildren<DiceEdge>())
            {
                _edgesMap[edge.EdgeNumber] = edge;
            }

            DirectionsToNumber = new Dictionary<Direction, int>
            {
                { Direction.Up, HighEdge.EdgeNumber },
                { Direction.Backward, BackwardEdge.EdgeNumber },
                { Direction.Forward, ForwardEdge.EdgeNumber },
                { Direction.Left, LeftEdge.EdgeNumber },
                { Direction.Right, RightEdge.EdgeNumber },
            };
        }

        public Direction GetDirectionByNumber(int number)
        {
            var edge = _edgesMap[number];

            if (edge == HighEdge)
                return Direction.Up;

            if (edge == LeftEdge)
                return Direction.Left;

            if (edge == RightEdge)
                return Direction.Right;

            if (edge == ForwardEdge)
                return Direction.Forward;

            if (edge == BackwardEdge)
                return Direction.Backward;

            return Direction.None;
        }
    }
}

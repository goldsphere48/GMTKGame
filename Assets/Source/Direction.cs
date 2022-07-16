using UnityEngine;

namespace GMTKGame
{
    public enum Direction
    {
        None,
        Forward,
        Backward,
        Left,
        Right,
        Up
    }

    public static class DirectionExt
    {
        public static Vector3 ToVector3(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Vector3(0, 1, 0);
                case Direction.Forward:
                    return new Vector3(0, 0, 1);
                case Direction.Backward:
                    return new Vector3(0, 0, -1);
                case Direction.Left:
                    return new Vector3(-1, 0, 0);
                case Direction.Right:
                    return new Vector3(1, 0, 0);
                default: 
                    return new Vector3(0, 0, 0);
            }
        }

        public static Vector3 ToVector3Angle(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Vector3(0, 0, 0);
                case Direction.Forward:
                    return new Vector3(90, 0, 0);
                case Direction.Backward:
                    return new Vector3(-90, 0, 0);
                case Direction.Left:
                    return new Vector3(0, 0, 90);
                case Direction.Right:
                    return new Vector3(0, 0, -90);
                default:
                    return new Vector3(0, 0, 0);
            }
        }
    }
}

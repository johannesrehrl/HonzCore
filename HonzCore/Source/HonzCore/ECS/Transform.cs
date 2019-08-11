using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoGame;

namespace HonzCore.ECS
{
    public class Transform
    {
        public Vector2 localPosition;
        public float localRotation;
        public Vector2 localScale = Vector2.One;

        public Matrix localMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(localPosition, 0)) * Matrix.CreateRotationZ(localRotation) * Matrix.CreateScale(new Vector3(localScale, 0));
            }
        }
        public Matrix worldMatrix
        {
            get
            {
                if (parent != null)
                    return parent.worldMatrix * localMatrix;
                return localMatrix;
            }
        }

        public GameObject gameObject;

        public Transform parent;
        public List<Transform> children = new List<Transform>();
    }
}

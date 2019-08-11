using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.Graphics
{
    public class Camera
    {
        float size
        {
            get=>_size;
            set
            {
                _size = value;
                RecalculateMatrix();
            }
        }
        float _size;
        Vector2 position
        {
            get => _position;
            set
            {
                _position = value;
                RecalculateMatrix();
            }
        }
        Vector2 _position;
        public float aspectRatio { get; private set; }

        public Matrix cameraMatrix { get; private set; }

        public Camera(float size, Vector2 position)
        {
            _size = size;
            _position = position;
            RecalculateMatrix();
        }
        
        internal void RecalculateMatrix()
        {
            Main.HonzCoreMain main = Main.HonzCoreMain.instance;

            aspectRatio = main.graphics.PreferredBackBufferWidth / (float)main.graphics.PreferredBackBufferHeight;

            cameraMatrix = Matrix.CreateOrthographicOffCenter(-size / 2 + position.X, size / 2 + position.X, -size / 2 / aspectRatio + position.Y, size / 2 / aspectRatio + position.Y, 0, 100);
            cameraMatrix *= Matrix.CreateScale(new Vector3(main.graphics.PreferredBackBufferWidth, -main.graphics.PreferredBackBufferHeight, 1));
            cameraMatrix *= Matrix.CreateTranslation(new Vector3(main.graphics.PreferredBackBufferWidth / 2, main.graphics.PreferredBackBufferHeight / 2, 0));
        }
    }
}

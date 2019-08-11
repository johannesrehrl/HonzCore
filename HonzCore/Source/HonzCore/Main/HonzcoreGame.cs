using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.Main
{
    public abstract class HonzCoreGame
    {
        public SpriteBatch spriteBatch
        {
            get => wrapper.spriteBatch;
        }
        public GraphicsDevice graphicsDevice
        {
            get => wrapper.GraphicsDevice;
        }
        public GraphicsDeviceManager graphics
        {
            get => wrapper.graphics;
        }

        internal HonzCoreWrapper wrapper;
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();
    }
}

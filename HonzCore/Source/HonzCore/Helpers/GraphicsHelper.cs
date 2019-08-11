using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HonzCore.Helpers
{
    class GraphicsHelper : IHelper
    {
        private static GraphicsHelper _instance;

        public static GraphicsHelper instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GraphicsHelper();
                }
                return _instance;
            }
        }
        private GraphicsHelper()
        {

        }

        List<Graphics.QueuedEntity> entities = new List<Graphics.QueuedEntity>();

        public void AddToQueue(Graphics.Entities.GraphicEntity entity, Matrix worldMatrix)
        {
            entities.Add(new Graphics.QueuedEntity(entity, worldMatrix));
        }
        public void DrawWorldTexture(Texture2D texture, Matrix worldMatrix, Color color)
        {
            Matrix view = worldMatrix * Helpers.ApplicationHelper.instance.activeScene.camera.cameraMatrix;
            Vector2 trans = Vector2.Transform(Vector2.Zero, view);

            Vector2 xScale = Vector2.TransformNormal(Vector2.UnitX, view);
            Vector2 yScale = Vector2.TransformNormal(Vector2.UnitY, view);

            Point posPoint = new Point((int)trans.X, (int)trans.Y);
            Point scalePoint = new Point((int)xScale.Length(), (int)yScale.Length());

            float angle = (float)Math.Acos(xScale.X / xScale.Length());

            Main.HonzCoreMain.instance.spriteBatch.Draw(texture, new Rectangle(posPoint, scalePoint), null, Color.White, angle, new Vector2(texture.Width/2f, texture.Height/2f), SpriteEffects.None, 0);
        }

        public void Initialize()
        {
            
        }
        public void Update(GameTime time)
        {
            
        }
        public void Draw(GameTime time)
        {
            Main.HonzCoreMain main = Main.HonzCoreMain.instance;
            main.graphicsDevice.Clear(Color.CornflowerBlue);
            main.spriteBatch.Begin();

            foreach(var ent in entities)
            {
                ent.entity.Draw(ent.worldMatrix);
            }
            main.spriteBatch.End();
            entities.Clear();
        }
    }
}
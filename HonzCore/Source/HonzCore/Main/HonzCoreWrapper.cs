using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;

using HonzCore.ECS;

namespace HonzCore.Main
{
    public class HonzCoreWrapper : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Scene scene;
        GameObject gm1;

        HonzCoreGame game;


        public HonzCoreWrapper(HonzCoreGame game)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.game = game;
        }

        protected override void Initialize()
        {
            HonzCoreMain.instance.Initialize();

            Helpers.ContentHelper.LoadTextures(Content, "Sprites");

            game.Initialize();


            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            HonzCoreMain.instance.Update(gameTime);
            game.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            HonzCoreMain.instance.Draw(gameTime);
            game.Draw();

            base.Draw(gameTime);
        }
    }
}

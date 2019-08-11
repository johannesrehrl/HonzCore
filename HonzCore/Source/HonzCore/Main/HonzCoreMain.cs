using HonzCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.Main
{
    public class HonzCoreMain
    {
        private bool isInit = false;

        List<Helpers.IHelper> helpers = new List<Helpers.IHelper>();

        HonzCoreGame game;

        public Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch
        {
            get => game.spriteBatch;
        }
        public Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice
        {
            get => game.graphicsDevice;
        }
        public Microsoft.Xna.Framework.GraphicsDeviceManager graphics
        {
            get => game.graphics;
        }

        private static HonzCoreMain _instance;
        public static HonzCoreMain instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HonzCoreMain();
                }
                return _instance;
            }
        }
        private HonzCoreMain()
        {

        }

        public void Run(HonzCoreGame game)
        {
            this.game = game;
            using (var wrapper = new HonzCoreWrapper(game))
                wrapper.Run();
        }

        internal void Initialize()
        {
            if (isInit)
                throw new InvalidOperationException("HonzCoreMain was already initialized");

            //Registers each Helper
            RegisterHelper(Helpers.ApplicationHelper.instance);
            RegisterHelper(Helpers.BlueprintHelper.instance);
            RegisterHelper(Helpers.ContentHelper.instance);
            RegisterHelper(Helpers.InputHelper.instance);
            RegisterHelper(Helpers.TimeHelper.instance);
            RegisterHelper(Helpers.GraphicsHelper.instance);

            //Initializes each Helper
            helpers.ForEach(x => x.Initialize());
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            helpers.ForEach(x => x.Update(gameTime));

            Helpers.ApplicationHelper.instance.activeScene.Update();
        }
        internal void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Helpers.ApplicationHelper.instance.activeScene.Draw();

            helpers.ForEach(x => x.Draw(gameTime));
        }

        public void RegisterHelper(Helpers.IHelper helper)
        {
            if(helpers.Contains(helper))
            {
                throw new InvalidOperationException("This Helper is already registered!");
            }
            helpers.Add(helper);
        }
    }
}

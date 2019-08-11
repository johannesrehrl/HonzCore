using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using HonzCore;
using HonzCore.ECS;

namespace HonzCore
{
    class Game1 : Main.HonzCoreGame
    {
        private Scene scene;
        private GameObject gm1;

        public override void Initialize()
        {
            scene = new Scene();

            gm1 = new GameObject();
            gm1.SetParent(scene.root);
            ECS.Component.TextureRenderer comp = new ECS.Component.TextureRenderer();
            comp.texture = Helpers.ContentHelper.GetTexture("Planetaris");
            gm1.AddComponent(comp);
            HonzCore.Helpers.ApplicationHelper.instance.LoadScene(scene);
        }
        public override void Draw()
        {

        }

        public override void Update()
        {

        }
    }
}

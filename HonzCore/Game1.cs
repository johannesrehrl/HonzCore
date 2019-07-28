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
            HonzCore.ECS.Component.TestComponent comp = new HonzCore.ECS.Component.TestComponent();
            gm1.AddComponent(comp);

            GameObject gm2 = gm1.Clone("Hannes");
            gm2.SetParent(gm1);
            HonzCore.Helpers.ApplicationHelper.instance.LoadScene(scene);
            System.Console.WriteLine(scene.root.FindChildren("Hannes", recursive: true, requireEnabled: true));

            HonzCore.Helpers.BlueprintHelper.instance.RegisterBlueprint(gm2, "TestBlueprint");
            var gm3 = HonzCore.Helpers.BlueprintHelper.instance.CreateBlueprint("TestBlueprint", gm2);
        }
        public override void Draw()
        {

        }

        public override void Update()
        {

        }
    }
}

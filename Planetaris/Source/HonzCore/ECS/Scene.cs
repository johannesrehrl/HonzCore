﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.ECS
{
    public class Scene
    {
        public GameObject root;
        public bool isActiveScene;

        public Scene ()
        {
            root = new GameObject();
            root.isRoot = true;
        }

        public void Update()
        {
            root.Update();
        }
        public void Draw()
        {
            root.Draw();
        }

        public void Destroy()
        {

        }

        ~Scene()
        {

        }
    }
}

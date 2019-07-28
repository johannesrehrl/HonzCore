using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.Main
{
    public abstract class HonzCoreGame
    {
        public abstract void Initialize();
        public abstract void Update();
        public abstract void Draw();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HonzCore.Graphics.Entities
{
    class BasicTextureGraphicEntity : GraphicEntity
    {
        public Texture2D texture;
        public Color color;

        public BasicTextureGraphicEntity(Texture2D texture, Color color)
        {
            this.texture = texture;
            this.color = color;
        }

        public override void Draw(Matrix worldMat)
        {
            Helpers.GraphicsHelper.instance.DrawWorldTexture(texture, worldMat, color);
        }
    }
}

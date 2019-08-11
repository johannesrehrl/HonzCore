using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.ECS.Component
{
    class TextureRenderer : Component
    {
        Graphics.Entities.BasicTextureGraphicEntity entity;
        Texture2D _texture;
        public Texture2D texture
        {
            get => _texture;
            set { _texture = value; UpdateEntity(); }
        }
        Color _color = Color.White;
        public Color color
        {
            get => _color;
            set { _color = value; UpdateEntity(); }
        }

        public override void OnCreate()
        {
            base.OnCreate();
            entity = new Graphics.Entities.BasicTextureGraphicEntity(_texture, _color);
        }

        private void UpdateEntity()
        {
            if(entity==null)
            {
                if (texture == null)
                    return;
                entity = new Graphics.Entities.BasicTextureGraphicEntity(texture, color);
                return;
            }
            entity.texture = texture;
            entity.color = color;
        }

        public override Component Clone()
        {
            TextureRenderer rend = new TextureRenderer();
            rend.color = color;
            rend.texture = texture;
            return rend;

        }
        public override void Draw()
        {
            base.Draw();
            if (entity != null)
                Helpers.GraphicsHelper.instance.AddToQueue(entity, gameObject.transform.worldMatrix);
        }
    }
}

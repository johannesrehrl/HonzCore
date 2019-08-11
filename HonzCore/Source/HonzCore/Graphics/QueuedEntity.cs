using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HonzCore.Graphics
{
    public struct QueuedEntity
    {
        public Entities.GraphicEntity entity;
        public Matrix worldMatrix;

        public QueuedEntity(Entities.GraphicEntity entity, Matrix worldMatrix)
        {
            this.entity = entity;
            this.worldMatrix = worldMatrix;
        }
    }
}

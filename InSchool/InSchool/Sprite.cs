using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InSchool
{
    public class Sprite
    {
        public float speed;
        public Texture2D texture;
        public Vector2 position;

        public Sprite(Texture2D texture, Vector2 position, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
        }

        public Sprite(Texture2D texture, Microsoft.Xna.Framework.Vector2 zero, float speed)
        {
            this.texture = texture;
            this.speed = speed;
        }

        public void Update()
        {
            position.X += speed;
        }
    }
}

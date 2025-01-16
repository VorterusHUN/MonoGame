using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSchool
{
    public class Sprite
    {
        public int speed;
        public Texture2D texture;
        public  Rectangle position;

        public Sprite(Texture2D texture, Rectangle position, int speed)
        {
            this.texture = texture;
            this.position = position;
            this.speed = speed;
        }

        public void Update()
        {
            position.X += speed;
        }
    }
}

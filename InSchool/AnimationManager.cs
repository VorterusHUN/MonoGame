using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InSchool
{
    public class AnimationManager
    {
        public int NumFrames;
        public int NumColumns;
        public System.Numerics.Vector2 size;

        int counter;
        int activeFrame;
        int interval;

        int rowPos;
        int colPos;

        public AnimationManager(int numFrames, int numColumns,System.Numerics.Vector2 size)
        {
            this.NumFrames = numFrames;
            this.NumColumns = numColumns;
            this.size = size;
        }

        public void Update()
        {
            counter++;
            if (counter > interval)
            {
                counter = 0;
                NextFrame();
            }
        }
        public void NextFrame()
        {
            activeFrame++;
            colPos++;
            if (activeFrame >= NumFrames)
            {
                activeFrame = 0;
                colPos = 0;
                rowPos = 0;
            }
            if(colPos >= NumColumns)
            {
                colPos = 0;
                rowPos++;
            }
        }
        public Microsoft.Xna.Framework.Rectangle GetFrame()
        {
            return new  Microsoft.Xna.Framework.Rectangle(colPos *(int)size.X, rowPos*(int)size.Y,(int)size.X, (int)size.Y);
        }
    }
}

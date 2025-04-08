using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lighting_System
{
    public class Cursor_Light_Spot : Light_Spot
    {
        public Cursor_Light_Spot(Texture2D texture, Vector2 position, float brightness, 
            Color color, float radius, float focus)
            : base(texture, position, brightness, color, radius, focus)
        { }
        public void Update(Vector2 newPosition)
        {
            _position = newPosition;
        }
    }
}

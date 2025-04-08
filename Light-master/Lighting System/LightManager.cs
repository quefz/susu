using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Lighting_System
{
    public class LightManager
    {
        private List<Light_Spot> _lights;
        private Cursor_Light_Spot _cursor;
        private float _delay = 0.5f;
        private float _current = 0f;
        public LightManager(List<Light_Spot> lights, Cursor_Light_Spot cursor)
        {
            _lights = lights;
            _cursor = cursor;
        }
        public void ToggleLight(int index)
        {
            if (index >= 0 && index < _lights.Count)
            {
                _lights[index].Toggle();
            }
        }
        public void KeyHandler(GameTime gameTime)
        {
            _current += (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState ks1 = Keyboard.GetState();
            for (int i = 0; i < 10; i++)
            {
                if (ks1.IsKeyDown((Keys)(Keys.D0 + i)) && _current >= _delay)
                {
                    ToggleLight(i);
                    _current = 0f;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch) {
            foreach (var light in _lights)
            {
                light.Draw(spriteBatch);
            }
            _cursor.Draw(spriteBatch);
        }
    }
}

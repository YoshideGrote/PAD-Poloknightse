﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Poloknightse
{
    class Score 
    {
        SpriteFont spriteFont;
        public Vector2 position;
        public string text;
        public int score;
        
        public Score()
        {
            spriteFont = GameEnvironment.ContentManager.Load<SpriteFont>("GameObjects/GameFont");
            position.X = 10;
            position.Y = 10;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont,text, position, Color.White);
        }
    }
}

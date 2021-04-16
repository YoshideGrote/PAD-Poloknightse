﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poloknightse
{
    class PlayingState : GameState
    {
        public Player player;

        public PlayingState()
        {
        }

        public override void Init()
        {
            LevelLoader.LoadLevel("Test");
            gameObjectList.Add(new Coin(Vector2.One.ToPoint()));
            gameObjectList.Add(new HealthPickup((Vector2.One * 2).ToPoint()));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            LevelLoader.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //Collision detection
            for (int i = gameObjectList.Count - 1; i >= 0; i--)
            {
                //Coin -> Player collision
                if (gameObjectList[i] is Coin)
                {
                    if (player.CheckCollision(gameObjectList[i]))
                    {
                        gameObjectList.Remove(gameObjectList[i]);
                        continue;
                    }
                }

                //HealthPickup -> Player collision
                if (gameObjectList[i] is HealthPickup)
                {
                    if (player.CheckCollision(gameObjectList[i]))
                    {
                        gameObjectList.Remove(gameObjectList[i]);
                        player.AddFollower(gameTime);
                        continue;
                    }
                }

                //Bullet -> Player collsion
                if (gameObjectList[i] is Bullet)
                {
                    if (player.CheckCollision(gameObjectList[i]))
                    {
                        player.TakeDamage(gameObjectList[i].gridPosition);
                        gameObjectList.Remove(gameObjectList[i]);
                        continue;
                    }
                }
            }
        }
    }
}

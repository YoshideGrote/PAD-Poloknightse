﻿using BaseProject.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject
{
    class PlayingState : GameState
    {
        public Player player;
        Score score = new Score();

        public PlayingState()
        {
        }

        public override void Init()
        {
            LevelLoader.LoadLevel("Level-1");
            gameObjectList.Add(new Coin(Vector2.One));
            gameObjectList.Add(new HealthPickup(Vector2.One*2));
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            score.Draw(spriteBatch);
            LevelLoader.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            score.text = "score: " + score.score;
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
                        score.score++;
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
                        gameObjectList.Remove(gameObjectList[i]);
                        player.TakeDamage(gameObjectList[i].gridPosition);
                        continue;
                    }
                }

            }
        }
    }
}

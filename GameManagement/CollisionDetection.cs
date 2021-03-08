﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BaseProject
{
    class CollisionDetection
    {
        public static void CheckWallCollision(GameObject gameObject)
        {
            //Check above player
            if (gameObject.velocity.Y == -1 && LevelLoader.tiles[(int)gameObject.gridPosition.X, (int)gameObject.gridPosition.Y - 1].tileType == Tile.TileType.WALL)
            {
                gameObject.velocity = Vector2.Zero;
            }

            //check below player
            if (gameObject.velocity.Y == 1 && LevelLoader.tiles[(int)gameObject.gridPosition.X, (int)gameObject.gridPosition.Y + 1].tileType == Tile.TileType.WALL)
            {
                gameObject.velocity = Vector2.Zero;
            }

            //Check right of player
            if (gameObject.velocity.X == 1 && LevelLoader.tiles[(int)gameObject.gridPosition.X + 1, (int)gameObject.gridPosition.Y].tileType == Tile.TileType.WALL)
            {
                gameObject.velocity = Vector2.Zero;
            }

            //Check left of player
            if (gameObject.velocity.X == -1 && LevelLoader.tiles[(int)gameObject.gridPosition.X - 1, (int)gameObject.gridPosition.Y].tileType == Tile.TileType.WALL)
            {
                gameObject.velocity = Vector2.Zero;
            }
        }
    }
}

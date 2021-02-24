﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject
{
    class LevelLoader
    {
        private static int gridTileSize = GameEnvironment.gridTileSize;
        private static Dictionary<Color, Texture2D> colorTexturePairs = new Dictionary<Color, Texture2D>();

        private static Tile[,] tiles;
        class Tile
        {
            public Texture2D tileTexture;
            public Rectangle rectangle;

            public Tile(Texture2D tileTexture, Rectangle rectangle)
            {
                this.tileTexture = tileTexture;
                this.rectangle = rectangle;
            }
        }

        public static void Initialize()
        {
            Texture2D wallTile = GameEnvironment.ContentManager.Load<Texture2D>("LevelTiles/Cell20");
            Texture2D groundTile = GameEnvironment.ContentManager.Load<Texture2D>("LevelTiles/Cell03");

            colorTexturePairs.Add(Color.Black, wallTile);
            colorTexturePairs.Add(Color.White, groundTile);
        }

        /// <summary>
        /// Load the level from a bmp file.
        /// </summary>
        /// <param name="levelName">Filename from the levels folder.</param>
        public static void LoadLevel(string levelName)
        {
            //Load the colors to a array
            Texture2D level = GameEnvironment.ContentManager.Load<Texture2D>("Levels/" + levelName);
            Color[] colors = new Color[level.Width * level.Height];
            level.GetData(colors);

            //Change the tile size and calculate the center
            gridTileSize = GameEnvironment.Screen.Y / level.Height;
            int xOffset = GameEnvironment.Screen.X / 2 - (level.Width / 2) * gridTileSize;
            int yOffset = GameEnvironment.Screen.Y / 2 - (level.Height / 2) * gridTileSize;

            //Here we check the colors of the image and assign the correct tileTexture to them.
            tiles = new Tile[level.Width, level.Height];

            for (int i = 0; i < colors.Length; i++)
            {
                Color pixel = colors[i];
                int x = i % level.Width;
                int y = i / level.Height;
                Rectangle rectangle = new Rectangle(x * gridTileSize + xOffset, y * gridTileSize + yOffset, gridTileSize, gridTileSize);

                tiles[x, y] = new Tile(colorTexturePairs[pixel], rectangle);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                spriteBatch.Draw(tile.tileTexture, tile.rectangle, Color.White);
            }
        }
    }
}

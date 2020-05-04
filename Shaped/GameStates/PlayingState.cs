using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Shaped.GameStates {
    class PlayingState : IGameLoopObject {

        private GameObjectList objectList = new GameObjectList();

        List<List<Point>> grid;

        public PlayingState() : base() {
            objectList.Add(new SpriteGameObject("title/spr_titleBackground", 0));
            grid = new List<List<Point>>(5);
            for (int i = 0; i < 5; i++) {
                grid.Add(new List<Point>(7));
                for (int j = 0; j < 7; j++) {
                    grid[i].Add(new Point(50 + j * 100, 300 + i * 50));
                    SpriteGameObject sprite = new SpriteGameObject("playing/spr_tile", 1);
                    sprite.Position = new Vector2(grid[i][j].X, grid[i][j].Y);
                    objectList.Add(sprite);
                    Console.WriteLine(i + ", " + j);
                }
            }

        }

        public void HandleInput(InputHelper inputHelper) {

        }

        public void Update(GameTime gameTime) {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            objectList.Draw(gameTime, spriteBatch);
        }

        public void Reset() {

        }
    }
}

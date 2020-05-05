using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shaped.GameObjects;
using System;
using System.Collections.Generic;

namespace Shaped.GameStates {
    class PlayingState : IGameLoopObject {

        private GameObjectList objectList = new GameObjectList();
        private GameObjectList enemies = new GameObjectList();
        private GameObjectList bullets = new GameObjectList();
        List<List<Point>> grid;

        Random random = new Random();
        int spawnSize = 200;

        Player player = new Player(3);

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
                }
            }
        }

        public void HandleInput(InputHelper inputHelper) {
            player.HandleInput(inputHelper);
        }

        public void Update(GameTime gameTime) {
            // spawn zombies
            if (random.Next(0, spawnSize) == 0) {
                Enemy enemy = new Enemy(random.Next(1, 51 - spawnSize / 4), 5);
                enemy.Position = new Vector2(GameEnvironment.Screen.X, grid[random.Next(0, 4)][0].Y);
                enemies.Add(enemy);
                if (spawnSize != 1)
                    spawnSize--;
            }
            // zombies hit the end
            if (enemies.Children.Count != 0) {
                for (int i = enemies.Children.Count - 1; i >= 0; i--) {

                    if (enemies.Children[i].Position.X < 0)
                        enemies.Children.Remove(enemies.Children[i]);
                }
            }
            enemies.Update(gameTime);

            //bullets
            foreach (Bullet bullet in bullets.Children) {
                foreach (Enemy enemy in enemies.Children) {
                    if (Math.Abs(bullet.Position.X - enemy.Position.X) < 50) {
                        bullets.Remove(bullet);
                        enemies.Remove(enemy);
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            objectList.Draw(gameTime, spriteBatch);
            enemies.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);
        }

        public void Reset() {

        }
    }
}

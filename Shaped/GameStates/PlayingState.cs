using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shaped.GameObjects;
using System;
using System.Collections.Generic;

namespace Shaped.GameStates {
    class PlayingState : IGameLoopObject {

        private GameObjectList objectList;
        private List<Enemy> enemies;
        private List<Turret> turrets;
        private List<Bullet> bullets;
        private List<List<Point>> grid;

        private Random random;
        private int spawnSize;

        private Player player;

        private TextGameObject lifeText;
        private int life;

        private TextGameObject CostText;
        private int turretCost;


        public PlayingState() : base() {
            Reset();
        }

        public void HandleInput(InputHelper inputHelper) {
            player.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space)) {

                //placement turret
                Vector2 position = new Vector2(player.Position.X, player.Position.Y + 25);
                foreach (List<Point> row in grid) {
                    if (Math.Abs(player.Position.Y + 40 - (row[0].Y + 25)) < 50)
                        foreach (Point cell in row) {
                            if (Math.Abs(player.Position.X - (cell.X + 50)) < 100)
                                position = new Vector2(cell.X + 25, cell.Y);
                        }

                }
                bool upgraded = false;
                foreach (Turret turret1 in turrets) {
                    if (turret1.Position == position) {
                        turret1.damage *= 2;
                        upgraded = true;
                        break;
                    }
                }

                // make turret
                if (!upgraded) {
                    Turret turret = new Turret(4);
                    turret.Position = position;
                    turrets.Add(turret);
                }

                // cost
                //life -= turretCost;
                turretCost = (int)(turretCost * 1.5f);
                CostText.Text = "Cost: " + turretCost.ToString();
            }
        }

        public void Update(GameTime gameTime) {
            // spawn enemy
            if (random.Next(0, spawnSize) == 0) {
                Enemy enemy = new Enemy(random.Next(1, 51 - spawnSize / 4), 5);
                enemy.Position = new Vector2(GameEnvironment.Screen.X, grid[random.Next(0, 4)][0].Y);
                enemies.Add(enemy);
                if (spawnSize != 1)
                    spawnSize--;
            }

            // enemy hits the end
            if (enemies.Count != 0) {
                for (int i = enemies.Count - 1; i >= 0; i--) {

                    if (enemies[i].Position.X < 0) {
                        enemies.Remove(enemies[i]);
                        life--;
                    }
                }
            }
            // enemies
            foreach (Enemy enemy1 in enemies) {
                enemy1.Update(gameTime);
            }

            //turrets
            for (int i = turrets.Count - 1; i >= 0; i--) {
                turrets[i].Update(gameTime, bullets, enemies);
            }


            //bullets
            for (int i = bullets.Count - 1; i >= 0; i--) {
                for (int j = enemies.Count - 1; j >= 0; j--) {
                    if (Math.Abs((enemies[j].Position.Y + 19) - (bullets[i].Position.Y + 5)) < 20) {
                        if (Math.Abs(enemies[j].Position.X - bullets[i].Position.X) < 10) {
                            enemies[j].HP -= bullets[i].damage;
                            bullets.Remove(bullets[i]);
                            if (enemies[j].HP <= 0) {
                                enemies.Remove(enemies[j]);
                                life++;
                            }
                            break;
                        }
                    }
                }
            }
            foreach (Bullet bullet in bullets) {
                bullet.Update(gameTime);
            }

            // player
            player.Update(gameTime);

            // life update
            lifeText.Text = life.ToString();
            if (life <= 0)
                GameEnvironment.GameStateManager.SwitchTo("GameOver");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            objectList.Draw(gameTime, spriteBatch);
            foreach (Turret turret in turrets) {
                turret.Draw(gameTime, spriteBatch);
            }
            foreach (Enemy enemy1 in enemies) {
                enemy1.Draw(gameTime, spriteBatch);
            }
            foreach (Bullet bullet in bullets) {
                bullet.Draw(gameTime, spriteBatch);
            }
            player.Draw(gameTime, spriteBatch);

        }

        public void Reset() {
            objectList = new GameObjectList();
            enemies = new List<Enemy>();
            turrets = new List<Turret>();
            bullets = new List<Bullet>();
            random = new Random();
            spawnSize = 200;
            life = 10;
            turretCost = 2;

            objectList.Add(new SpriteGameObject("title/spr_titleBackground", 0));

            player = new Player(3);
            player.Position = new Vector2(GameEnvironment.Screen.X / 4, 375);

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


            lifeText = new TextGameObject("fonts/Arial40");
            lifeText.Text = life.ToString();
            lifeText.Color = Color.Black;
            lifeText.Position = new Vector2(GameEnvironment.Screen.X / 2, GameEnvironment.Screen.Y / 5);
            objectList.Add(lifeText);

            CostText = new TextGameObject("fonts/Arial12");
            CostText.Position = new Vector2(25, 25);
            CostText.Color = Color.Black;
            CostText.Text = "Cost: " + turretCost.ToString();
            objectList.Add(CostText);
        }
    }
}

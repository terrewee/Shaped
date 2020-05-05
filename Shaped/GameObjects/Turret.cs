using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Shaped.GameObjects {
    class Turret : SpriteGameObject {

        private int timer = 0;
        private bool idle = true;

        public Turret(int layer = 0, string id = "", int sheetIndex = 0) : base("playing/spr_turret", layer, id, sheetIndex) {

        }

        public void Update(GameTime gameTime, GameObjectList bullets, GameObjectList enemies) {
            base.Update(gameTime);
            idle = true;
            foreach (Enemy enemy in enemies.Children) {
                if (Math.Abs((enemy.Position.Y + 19) - (this.Position.Y + 5)) < 30)
                    idle = false;
            }
            if (!idle) {
                if (timer == 60) {
                    timer = 0;
                    Bullet bullet = new Bullet();
                    bullet.Position = new Vector2(Position.X + sprite.Width, position.Y - 5 + sprite.Height / 2);
                    bullets.Add(bullet);
                }
                timer++;
            }
        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            base.Draw(gameTime, spriteBatch);
        }
    }
}

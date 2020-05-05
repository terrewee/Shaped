using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shaped.GameObjects {
    class Bullet : SpriteGameObject {

        private int speed = 2;

        public Bullet(int layer = 0, string id = "", int sheetIndex = 0) : base("playing/spr_bullet", layer, id, sheetIndex) {

        }

        public override void Update(GameTime gameTime) {
            position.X += speed;
            base.Update(gameTime);

        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            base.Draw(gameTime, spriteBatch);
        }

        public int Speed {
            get { return speed; }
            set { speed = value; }
        }
    }
}

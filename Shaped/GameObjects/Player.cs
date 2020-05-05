using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shaped.GameObjects {
    class Player : SpriteGameObject {

        private int animation = 0;
        private bool animationReverser = false;
        private int speed = 2;
        private bool idle;

        public Player(int layer = 0, string id = "", int sheetIndex = 0) : base("playing/spr_player@4x2", layer, id, sheetIndex) {

        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);
            idle = true;
            if (inputHelper.IsKeyDown(Keys.S) || inputHelper.IsKeyDown(Keys.Down)) {
                position.Y += speed;
                animation = 1;
                idle = false;
            }
            if (inputHelper.IsKeyDown(Keys.W) || inputHelper.IsKeyDown(Keys.Up)) {
                position.Y -= speed;
                animation = 1;
                idle = false;
            }
            if (inputHelper.IsKeyDown(Keys.D) || inputHelper.IsKeyDown(Keys.Right)) {
                position.X += speed;
                animation = 1;
                idle = false;
            }
            if (inputHelper.IsKeyDown(Keys.A) || inputHelper.IsKeyDown(Keys.Left)) {
                position.X -= speed;
                animation = 1;
                idle = false;
            }
            if (idle) {
                animation = 0;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            switch (animation) {

                case 0:
                    // idle
                    sprite.SheetIndex = 0;
                    break;
                case 1:
                    // walk
                    if (sprite.SheetIndex == 0)
                        sprite.SheetIndex = 4;
                    else {
                        if (!animationReverser) {
                            if (sprite.SheetIndex == 7)
                                animationReverser = true;
                            else
                                sprite.SheetIndex++;
                        }
                        else
                             if (sprite.SheetIndex == 1)
                            animationReverser = false;
                        else
                            sprite.SheetIndex--;
                    }
                    break;
            }

            base.Draw(gameTime, spriteBatch);
        }
    }
}

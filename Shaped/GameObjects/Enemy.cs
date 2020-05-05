using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shaped.GameObjects {
    class Enemy : SpriteGameObject {

        private int animation = 0;
        private bool animationReverser = false, animationReverser2 = false, animationReverser3 = false;
        private int speed = 2;
        public int HP = 1;
        private SpriteSheet sprite2;
        private SpriteSheet sprite3;
        private bool visible2 = false, visible3 = false;
        bool animationDelay = true;

        public Enemy(int hp, int layer = 0, string id = "", int sheetIndex = 0) : base("playing/spr_enemy@5x4", layer, id, sheetIndex) {
            HP = hp;
            sprite2 = sprite;
            sprite3 = sprite;
            if (HP > 5) {
                visible2 = true;
                if (HP > 10)
                    visible3 = true;
            }
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            if (HP < 6) {
                visible2 = false;
                if (HP < 11)
                    visible3 = false;
            }
            position.X -= speed;
        }

        public override void HandleInput(InputHelper inputHelper) {
            base.HandleInput(inputHelper);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (animationDelay)
                animationDelay = false;
            else {
                switch (animation) {

                    case 0:
                        // move
                        if (sprite.SheetIndex > 11) {
                            sprite.SheetIndex = 5;
                        }
                        else {
                            if (!animationReverser) {
                                if (sprite.SheetIndex == 11)
                                    animationReverser = true;
                                else
                                    sprite.SheetIndex++;
                            }
                            else
                                 if (sprite.SheetIndex == 0)
                                animationReverser = false;
                            else
                                sprite.SheetIndex--;
                        }
                        if (sprite2.SheetIndex > 11) {
                            sprite2.SheetIndex = 11;
                        }
                        else {
                            if (!animationReverser2) {
                                if (sprite2.SheetIndex == 11)
                                    animationReverser2 = true;
                                else
                                    sprite2.SheetIndex++;
                            }
                            else
                                 if (sprite2.SheetIndex == 0)
                                animationReverser2 = false;
                            else
                                sprite2.SheetIndex--;
                        }
                        if (sprite3.SheetIndex > 11) {
                            sprite3.SheetIndex = 0;
                        }
                        else {
                            if (!animationReverser3) {
                                if (sprite3.SheetIndex == 11)
                                    animationReverser3 = true;
                                else
                                    sprite3.SheetIndex++;
                            }
                            else
                                 if (sprite3.SheetIndex == 0)
                                animationReverser3 = false;
                            else
                                sprite3.SheetIndex--;
                        }
                        break;
                    case 1:
                        // attack
                        if (sprite.SheetIndex < 12) {
                            sprite.SheetIndex = 17;
                        }
                        else {
                            if (!animationReverser) {
                                if (sprite.SheetIndex == 19)
                                    animationReverser = true;
                                else
                                    sprite.SheetIndex++;
                            }
                            else
                                 if (sprite.SheetIndex == 12)
                                animationReverser = false;
                            else
                                sprite.SheetIndex--;
                        }
                        if (sprite2.SheetIndex < 12) {
                            sprite2.SheetIndex = 12;
                        }
                        else {
                            if (!animationReverser2) {
                                if (sprite2.SheetIndex == 19)
                                    animationReverser2 = true;
                                else
                                    sprite2.SheetIndex++;
                            }
                            else
                                 if (sprite2.SheetIndex == 12)
                                animationReverser2 = false;
                            else
                                sprite2.SheetIndex--;
                        }
                        if (sprite3.SheetIndex < 12) {
                            sprite3.SheetIndex = 19;
                        }
                        else {
                            if (!animationReverser3) {
                                if (sprite3.SheetIndex == 19)
                                    animationReverser3 = true;
                                else
                                    sprite3.SheetIndex++;
                            }
                            else
                                 if (sprite3.SheetIndex == 12)
                                animationReverser3 = false;
                            else
                                sprite3.SheetIndex--;
                        }
                        break;
                }
                animationDelay = true;
            }
            if (visible2)
                sprite2.Draw(spriteBatch, new Vector2(this.GlobalPosition.X + 10, this.GlobalPosition.Y - 30), origin);

            if (visible3)
                sprite3.Draw(spriteBatch, new Vector2(this.GlobalPosition.X - 12, this.GlobalPosition.Y - 16), origin);
            base.Draw(gameTime, spriteBatch);
        }
    }
}

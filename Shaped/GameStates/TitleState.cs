using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shaped.GameStates {
    class TitleState : IGameLoopObject {

        GameObjectList objectList = new GameObjectList();
        SpriteGameObject play;
        private bool playBig;
        private bool playWait;

        public TitleState() : base() {
            objectList.Add(new SpriteGameObject("title/spr_titleBackground", 0));

            SpriteGameObject title = new SpriteGameObject("title/spr_title", 1);
            title.Position = new Vector2(GameEnvironment.Screen.X / 2 - title.Sprite.Width / 2, GameEnvironment.Screen.Y / 3 - title.Sprite.Height / 2);
            objectList.Add(title);

            play = new SpriteGameObject("title/spr_arrow@3x2", 1);
            play.Position = new Vector2(GameEnvironment.Screen.X / 2 - play.Sprite.Width / 2, GameEnvironment.Screen.Y / 3 * 2 - play.Sprite.Height / 2);
            objectList.Add(play);
            playBig = false;
            playWait = true;

            TextGameObject enter = new TextGameObject("fonts/Arial40", 1);
            enter.Text = "Enter";
            enter.Position = new Vector2(GameEnvironment.Screen.X / 2 - enter.Size.X / 2, GameEnvironment.Screen.Y / 5 * 4 - enter.Size.Y / 2);
            enter.Color = Color.Black;
            objectList.Add(enter);
        }

        public void HandleInput(InputHelper inputHelper) {
            if (inputHelper.AnyKeyPressed) {
                GameEnvironment.GameStateManager.SwitchTo("Playing");
                GameEnvironment.GameStateManager.Reset();
            }
        }

        public void Update(GameTime gameTime) {
            if (!playBig) {
                if (play.Sprite.SheetIndex != 5) {
                    if (playWait)
                        playWait = false;
                    else {
                        play.Sprite.SheetIndex++;
                        playWait = true;
                    }
                }
                else
                    playBig = true;

            }
            else {
                if (play.Sprite.SheetIndex != 0)
                    if (playWait)
                        playWait = false;
                    else {
                        play.Sprite.SheetIndex--;
                        playWait = true;
                    }
                else
                    playBig = false;

            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            objectList.Draw(gameTime, spriteBatch);
        }

        public void Reset() {

        }
    }
}

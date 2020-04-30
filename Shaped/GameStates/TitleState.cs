using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede.GameStates {
    class TitleState : IGameLoopObject {

        GameObjectList objectList = new GameObjectList();

        public TitleState() : base() {
            objectList.Add(new SpriteGameObject("spr_titleBackground", 0));
            SpriteGameObject title = new SpriteGameObject("spr_title", 1);
            title.Position = new Vector2(GameEnvironment.Screen.X / 2 - title.Sprite.Width / 2, GameEnvironment.Screen.Y / 3 - title.Sprite.Height / 2);
            objectList.Add(title);
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

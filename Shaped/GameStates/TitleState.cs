using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Centipede.GameStates {
    class TitleState : IGameLoopObject {

        GameObjectList objectList = new GameObjectList(0, "background");

        public TitleState() : base() {
            objectList.Add(new SpriteGameObject("spr_titleBackground"));
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

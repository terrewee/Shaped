using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Shaped.GameStates {
    class GameOverState : IGameLoopObject {

        GameObjectList objectList;

        TextGameObject gameover;
        public GameOverState() : base() {
            Reset();
        }

        public void HandleInput(InputHelper inputHelper) {
            if (inputHelper.KeyPressed(Keys.Enter) || inputHelper.KeyPressed(Keys.Space))
                GameEnvironment.GameStateManager.SwitchTo("Title");
        }

        public void Update(GameTime gameTime) {
            objectList.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            objectList.Draw(gameTime, spriteBatch);
        }

        public void Reset() {
            objectList = new GameObjectList();

            gameover = new TextGameObject("fonts/Arial40");
            gameover.Text = "GAMEOVER";
            gameover.Position = new Vector2((GameEnvironment.Screen.X / 2) - (gameover.Text.Length * 40 / 2), GameEnvironment.Screen.Y / 2 - gameover.Text.Length / 2 - 100);
            objectList.Add(gameover);
        }
    }
}

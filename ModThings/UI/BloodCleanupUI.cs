using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework.Graphics;

namespace _144Prisos.ModThings.UI
{
    public class BloodCleanUpUI : UIState
    {
        private UIPanel bookPanel;
        private UIText bookText;
        private int currentPage;
        private bool visible;

        public override void OnInitialize()
        {
            bookPanel = new UIPanel();
            bookPanel.SetPadding(10);
            bookPanel.Left.Set(Main.screenWidth / 2 - 150, 0f);
            bookPanel.Top.Set(Main.screenHeight / 2 - 150, 0f);
            bookPanel.Width.Set(300f, 0f);
            bookPanel.Height.Set(300f, 0f);
            bookPanel.BackgroundColor = new Color(63, 82, 151) * 0.8f;
            bookPanel.BorderColor = Color.Black;
            Append(bookPanel);

            bookText = new UIText("");
            bookText.Left.Set(10f, 0f);
            bookText.Top.Set(10f, 0f);
            bookPanel.Append(bookText);

            UIPanel prevPageButton = new UIPanel();
            prevPageButton.Width.Set(40f, 0f);
            prevPageButton.Height.Set(20f, 0f);
            prevPageButton.Left.Set(10f, 0f);
            prevPageButton.Top.Set(bookPanel.Height.Pixels - 30f, 0f);
            prevPageButton.BackgroundColor = Color.LightGray;
            prevPageButton.OnLeftClick += (evt, element) =>
            {
                if (currentPage > 0)
                    currentPage--;
                UpdateText();
            };
            bookPanel.Append(prevPageButton);

            UIPanel nextPageButton = new UIPanel();
            nextPageButton.Width.Set(40f, 0f);
            nextPageButton.Height.Set(20f, 0f);
            nextPageButton.Left.Set(bookPanel.Width.Pixels - 50f, 0f);
            nextPageButton.Top.Set(bookPanel.Height.Pixels - 30f, 0f);
            nextPageButton.BackgroundColor = Color.LightGray;
            nextPageButton.OnLeftClick += (evt, element) =>
            {
                if (currentPage < 2) // Change this value based on the number of pages
                    currentPage++;
                UpdateText();
            };
            bookPanel.Append(nextPageButton);

            UIPanel closeButton = new UIPanel();
            closeButton.Width.Set(20f, 0f);
            closeButton.Height.Set(20f, 0f);
            closeButton.Left.Set(bookPanel.Width.Pixels - 30f, 0f);
            closeButton.Top.Set(10f, 0f);
            closeButton.BackgroundColor = Color.Red;
            closeButton.OnLeftClick += (evt, element) => { visible = false; };
            bookPanel.Append(closeButton);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                base.Draw(spriteBatch);
            }
        }

        public void ToggleVisibility()
        {
            visible = !visible;
            if (visible)
            {
                currentPage = 0;
                UpdateText();
            }
        }

        private void UpdateText()
        {
            switch (currentPage)
            {
                case 0:
                    bookText.SetText("Page 1 content");
                    break;
                case 1:
                    bookText.SetText("Page 2 content");
                    break;
                case 2:
                    bookText.SetText("Page 3 content");
                    break;
            }
        }
    }

    public class MyMod : Mod
    {
        private UserInterface bookInterface;
        private BloodCleanUpUI bookUI;
        private bool bookUIVisible;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                bookUI = new BloodCleanUpUI();
                bookInterface = new UserInterface();
                bookInterface.SetState(bookUI);
            }
        }

        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (bookUIVisible)
            {
                bookInterface.Draw(Main.spriteBatch, new GameTime());
            }
        }

        public override void HandleUI(UserInterface ui, UIElement element)
        {
            if (bookUIVisible)
            {
                bookInterface?.HandleUI(Main.LocalPlayer, ui, element);
            }
        }

        public override void PostUpdateInput()
        {
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.B) && !Main.oldKeyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.B))
            {
                bookUIVisible = !bookUIVisible;
                bookUI.ToggleVisibility();
            }
        }
    }
}

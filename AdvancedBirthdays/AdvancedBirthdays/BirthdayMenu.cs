using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;


namespace AdvancedBirthdays
{
    class BirthdayMenu : IClickableMenu
    {
        //FOR LATER:
        //Calculation for real life birthday to stardew birthday
        // [(day/# of days in month) X 9.3] + (months that have occurred since the beginning of the season X 9.3)

        private readonly List<ClickableTextureComponent> months = new List<ClickableTextureComponent>();

        float birthdayMonth;
        float birthdayDay;

        /********************
         *  Public methods
         *  
         *****************/

        public BirthdayMenu(float pMonth, float pDay) 
            : base(Game1.viewport.Width / 2 - (632 + IClickableMenu.borderWidth * 2) / 2, Game1.viewport.Height / 2 - (600 + IClickableMenu.borderWidth * 2) / 2 - Game1.tileSize, 632 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2 + Game1.tileSize, true)
        {
            birthdayMonth = pMonth;
            birthdayDay = pDay;
            this.setUpClickableObjects();
        }

        public override void gameWindowSizeChanged(Rectangle oldBounds, Rectangle newBounds)
        {
            base.gameWindowSizeChanged(oldBounds, newBounds);
            this.xPositionOnScreen = Game1.viewport.Width / 2 - (632 + IClickableMenu.borderWidth * 2) / 2;
            this.yPositionOnScreen = Game1.viewport.Height / 2 - (600 + IClickableMenu.borderWidth * 2) / 2 - Game1.tileSize;
            this.setUpClickableObjects();
        }


        /// <summary>Draw the menu to the screen.</summary>
        /// <param name="b">The sprite batch.</param>
        public override void draw(SpriteBatch b)
        {
            setValues();
            Game1.drawDialogueBox(this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, false, true);

            foreach (ClickableTextureComponent button in months)
            {
                button.draw(b);
            }

            this.drawMouse(b);
            base.draw(b);
        }

        /// <summary>
        /// Check for left click
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="playSound"></param>
        public override void receiveLeftClick(int x, int y, bool playSound = true)
        {
            base.receiveLeftClick(x, y, playSound);
        }

        /********************
         *  Private methods
         *  
         *****************/

        /// <summary>
        /// Set values of birthday menu screen size
        /// </summary>
        /// 
        private void setValues()
        {
            this.width = Game1.viewport.Width - 200;
            this.height = Game1.viewport.Height - 100;
        }

        private void setUpClickableObjects()
        {
            this.months.Clear();
            
            //1st layer months
            this.months.Add(new ClickableTextureComponent("January", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\January"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("February", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 4 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\February"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("March", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 7 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\March"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("April", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 10 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\April"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("May", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 13 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\May"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("June", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 16 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\June"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            
            //2nd layer months
            this.months.Add(new ClickableTextureComponent("Juli", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\Juli"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("August", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\August"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("September", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\September"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("October", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\October"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("November", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\November"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));
            this.months.Add(new ClickableTextureComponent("December", new Rectangle(this.xPositionOnScreen + IClickableMenu.spaceToClearSideBorder + IClickableMenu.borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4, this.yPositionOnScreen + IClickableMenu.borderWidth + IClickableMenu.spaceToClearTopBorder + 80, 150, 35), "", "", Game1.content.Load<Texture2D>("LooseSprites/months\\December"), new Rectangle(0, 0, 150, 35), Game1.pixelZoom / 3.5f));

        }

        


    }


}

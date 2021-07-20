using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace AdvancedBirthdays
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Public methods
        *********/
        private NPC _birthdayNPC;

        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }
        
        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        /// 
        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            CheckForBirthday();
        }

        /// <summary>
        /// Press F10 for screen to appear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button == SButton.F10 && Context.IsPlayerFree)
            {
                Game1.activeClickableMenu = new BirthdayMenu(4, 15);
                this.Monitor.Log("Values changed:", LogLevel.Debug);
                this.Monitor.Log("X = " + Game1.activeClickableMenu.xPositionOnScreen, LogLevel.Debug);
                this.Monitor.Log("Y = " + Game1.activeClickableMenu.yPositionOnScreen, LogLevel.Debug);
            }
        }

        private void CheckForBirthday()
        {
            _birthdayNPC = null;
            foreach (var location in Game1.locations)
            {
                foreach (var character in location.characters)
                {
                    if (character.isBirthday(Game1.currentSeason, Game1.dayOfMonth))
                    {
                        _birthdayNPC = character;
                        BdayNotifications(_birthdayNPC.displayName, CharacterLikes(_birthdayNPC.displayName));
                        break;
                    }
                }

                if (_birthdayNPC != null)
                    break;
            }
        }

        private string CharacterLikes(string npcName)
        {
            switch (npcName)
            {
                //Spring kids
                case "Kent":
                    return "a daffodil";
                case "Lewis":
                    return "a blueberry";
                case "Vincent":
                    return "a daffodil";
                case "Haley":
                    return "a daffodil";
                case "Pam":
                    return "a daffodil";
                case "Shane":
                    return "a normal egg";
                case "Piere":
                    return "a daffodil";
                case "Emily":
                    return "a daffodil";

                //Summer kids
                case "Jas":
                    return "a daffodil";
                case "Gus":
                    return "a daffodil";
                case "Maru":
                    return "a quartz";
                case "Alex":
                    return "a dandelion";
                case "Sam":
                    return "a Joja Cola";
                case "Demetrius":
                    return "a purple mushroom";
                case "Willy":
                    return "a quartz";

                //Fall kids
                case "Penny":
                    return "a leek";
                case "Elliott":
                    return "a squid";
                case "Jodi":
                    return "some milk";
                case "Abigail":
                    return "a quartz";
                case "Sandy":
                    return "a quartz";
                case "Marnie":
                    return "a quartz";
                case "Robin":
                    return "a quartz";
                case "George":
                    return "a leek";

                //Winter kids
                case "Linus":
                    return "a spring union";
                case "Caroline":
                    return "a daffodil";
                case "Sebastian":
                    return "a quartz";
                case "Harvey":
                    return "a hazelnut";
                case "Wizard":
                    return "a quartz";
                case "Evelyn":
                    return "a daffodil";
                case "Leah":
                    return "a snow yam";
                case "Clint":
                    return "a copper bar";

                default:
                    return "something";
            }
        }

        private void BdayNotifications(string name, string likeItem)
        {
            Game1.addHUDMessage(new HUDMessage("It is " + name + "'s birthday! Maybe you could give them " + likeItem, 2));
        }
    }
}

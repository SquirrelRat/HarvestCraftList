using System;
using System.Collections.Generic;
using ExileCore;
using ExileCore.PoEMemory.Elements;
using SharpDX;

namespace HarvestCraftList
{
    public class Core : BaseSettingsPlugin<Settings>
    {
    public override bool Initialise()
        {
            return base.Initialise();
        }

        public override void Render()
        {
            var harvestWindow = GameController.Game.IngameState.IngameUi.HarvestWindow;

            if (harvestWindow.IsVisibleLocal)
            {
                var harvestCrafts = harvestWindow.Crafts;
                var topLeft = GameController.Game.IngameState.IngameUi.GetClientRectCache.TopLeft;
                topLeft.Y += 100;

                foreach (var craft in harvestCrafts)
                {
                    if (Int16.Parse(craft.Count) > 0)
                    {
                        switch (craft.ParsedName)
                        {
                            case string a when (a.Contains("Reforge") && a.Contains("White")):                      //white sockets
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.White);
                                break;
                            case string a when a.Contains("Augment"):                                               //augs
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Green);
                                break;
                            case string a when (a.Contains("Remove") && a.Contains("non-") && a.Contains("add")):   //remove-non/add
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Orange);
                                break;
                            case string a when (a.Contains("Remove") && a.Contains("add")):                         //remove/add
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Yellow);
                                break;
                            case string a when a.Contains("Remove"):                                                //remove
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Red);
                                break;
                            case string a when a.Contains("Corrupt an item 10 times"):                              //10 corrupt
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.DarkRed);
                                break;
                            case string a when a.Contains("Nemesis"):                                               //nemesis map mod
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Pink);
                                break;
                            case string a when (a.Contains("Fossil") || a.Contains("Essences") || a.Contains("Delirium Orbs") || a.Contains("Oils") || a.Contains("Catalysts") || a.Contains("Splinters"))://exchange
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Blue);
                                break;
                            case string a when (a.Contains("all Prefixes") || a.Contains("all Suffixes")):          //reforge keep
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Lime);
                                break;
                            case string a when (a.Contains("Atlas Mission") || a.Contains("Tier 14 Map")):          //map sacrifice
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Magenta);
                                break;
                            case string a when (a.Contains("Fracture") || a.Contains("Synthesise")):                //synth and fracture
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Gold);
                                break;
                            case string a when (a.Contains("six sockets") || a.Contains("Divination Card")):        //6-socket and  or divcards
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Gray);
                                break;
                            case string a when a.Contains("Exalted Orb"):                                            //10c to ex
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Gold);
                                break;
                            case string a when ((a.Contains("Upgrade") || a.Contains("upgrade") || a.Contains("Offering to the Goddess") || a.Contains("Scarab")) && !a.Contains("Normal") && !a.Contains("Magic")):          //random upgrades
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Indigo);
                                break;
                            case string a when a.Contains("Influence"):                                            //10c to ex
                                Graphics.DrawText(craft.ParsedName, topLeft, Color.Aqua);
                                break;
                        }
                        topLeft.Y += 10;
                    }
                }
            }
        }

    }
}

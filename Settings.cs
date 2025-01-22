using ModSettings;

namespace DroppableUndroppables
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();

        [Section("Droppable Undroppables Settings")]

        [Name("Enable Items")]
        [Description("Turns all regular items droppable. Misc items will not receive adjustements such as weight. (Requires Scene Reload/Transition)")]
        public bool AllItem = true;

        [Name("Item Weight")]
        [Description("Gives certain important items such as the Respirator or Camera weight, for balance. Misc items will not receive any weight. (Requires Scene Reload/Transition)")]
        public bool ImportantWeight = true;

        [Name("Enable Collectibles")]
        [Description("Turns all collectible items such as notes, keys and the technical backpack into droppable inventory items. These won't have other adjustements such as weight. THIS WILL MAKE ALL NOTES UNREADABLE! (Requires Scene Reload/Transition)")]
        public bool AllNote = false;



        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. (Confirm and Scene Transition/Reload required.)")]
        public bool ResetSettings = false;


        protected override void OnConfirm()
        {
            ApplyReset();
            instance.ResetSettings = false;
            base.OnConfirm();
            base.RefreshGUI();
        }

        public static void ApplyReset()
        {
            if (instance.ResetSettings == true)
            {
                instance.AllItem = true;
                instance.AllNote = false;
                instance.ImportantWeight = true;
                instance.ResetSettings = false;
            }
        }
    }


}

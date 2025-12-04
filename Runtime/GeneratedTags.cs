namespace DTT.ExtendedDebugLogs
{
    public static class SaveTags
    {
        #region Properties

        public static Tag Saved => TagContainerCollection.GetContainer("Demo Tags").GetTag("SaveTags", "Saved");
        public static Tag Loaded => TagContainerCollection.GetContainer("Demo Tags").GetTag("SaveTags", "Loaded");

        public static Tag CorruptSave =>
            TagContainerCollection.GetContainer("Demo Tags").GetTag("SaveTags", "CorruptSave");

        #endregion
    }

    public static class ShopTags
    {
        #region Properties

        public static Tag CashShop => TagContainerCollection.GetContainer("Demo Tags").GetTag("ShopTags", "CashShop");
        public static Tag FreeItems => TagContainerCollection.GetContainer("Demo Tags").GetTag("ShopTags", "FreeItems");

        public static Tag PlayerItems =>
            TagContainerCollection.GetContainer("Demo Tags").GetTag("ShopTags", "PlayerItems");

        #endregion
    }

    public static class UITags
    {
        #region Properties

        public static Tag Settings => TagContainerCollection.GetContainer("Demo Tags").GetTag("UITags", "Settings");
        public static Tag Menu => TagContainerCollection.GetContainer("Demo Tags").GetTag("UITags", "Menu");
        public static Tag Paywall => TagContainerCollection.GetContainer("Demo Tags").GetTag("UITags", "Paywall");
        public static Tag Saving => TagContainerCollection.GetContainer("Demo Tags").GetTag("UITags", "Saving");
        public static Tag Loading => TagContainerCollection.GetContainer("Demo Tags").GetTag("UITags", "Loading");

        #endregion
    }

    public static class AnimationsTags
    {
        #region Properties

        public static Tag NPC => TagContainerCollection.GetContainer("Demo Tags").GetTag("AnimationsTags", "NPC");
        public static Tag Player => TagContainerCollection.GetContainer("Demo Tags").GetTag("AnimationsTags", "Player");
        public static Tag Enemy => TagContainerCollection.GetContainer("Demo Tags").GetTag("AnimationsTags", "Enemy");

        #endregion
    }

    public static class SoundEffectsTags
    {
        #region Properties

        public static Tag Environment =>
            TagContainerCollection.GetContainer("Demo Tags").GetTag("SoundEffectsTags", "Environment");

        #endregion
    }

    public static class SettingTag
    {
        #region Properties

        public static Tag Screen => TagContainerCollection.GetContainer("Marmary Tags").GetTag("SettingTag", "Screen");
        public static Tag Render => TagContainerCollection.GetContainer("Marmary Tags").GetTag("SettingTag", "Render");

        #endregion
    }

    public static class FlowControlTag
    {
        #region Properties

        public static Tag Event =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("FlowControlTag", "Event");

        public static Tag Constructor =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("FlowControlTag", "Constructor");

        public static Tag Setup =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("FlowControlTag", "Setup");

        public static Tag EntryPoint =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("FlowControlTag", "EntryPoint");

        #endregion
    }

    public static class SaveTag
    {
        #region Properties

        public static Tag Load => TagContainerCollection.GetContainer("Marmary Tags").GetTag("SaveTag", "Load");

        #endregion
    }

    public static class UITag
    {
        #region Properties

        public static Tag Menu => TagContainerCollection.GetContainer("Marmary Tags").GetTag("UITag", "Menu");

        #endregion
    }

    public static class GameTag
    {
        #region Properties

        public static Tag GridDebug =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("GameTag", "GridDebug");

        #endregion
    }

    public static class DataBaseTag
    {
        #region Properties

        public static Tag StatsDeep =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("DataBaseTag", "StatsDeep");

        public static Tag Stats => TagContainerCollection.GetContainer("Marmary Tags").GetTag("DataBaseTag", "Stats");

        #endregion
    }

    public static class GameplayTag
    {
        #region Properties

        public static Tag GridDebug =>
            TagContainerCollection.GetContainer("Marmary Tags").GetTag("GameplayTag", "GridDebug");

        public static Tag Turn => TagContainerCollection.GetContainer("Marmary Tags").GetTag("GameplayTag", "Turn");
        public static Tag Battle => TagContainerCollection.GetContainer("Marmary Tags").GetTag("GameplayTag", "Battle");
        public static Tag Round => TagContainerCollection.GetContainer("Marmary Tags").GetTag("GameplayTag", "Round");

        #endregion
    }
}
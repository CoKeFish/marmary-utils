// THIS IS A GENERATED FILE BY THE EXTENDED DEBUG LOGS PACKAGE

namespace DTT.ExtendedDebugLogs
{
	public static class BattleTag
	{
		public static Tag Turn => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "Turn");
		public static Tag Round => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "Round");
		public static Tag Movement => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "Movement");
		public static Tag StateMachine => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "StateMachine");
		public static Tag Pool => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "Pool");
		public static Tag Preparation => TagContainerCollection.GetContainer("HRTags").GetTag("BattleTag", "Preparation");
	}
	public static class GridTag
	{
		public static Tag Selection => TagContainerCollection.GetContainer("HRTags").GetTag("GridTag", "Selection");
		public static Tag Paint => TagContainerCollection.GetContainer("HRTags").GetTag("GridTag", "Paint");
		public static Tag Debug => TagContainerCollection.GetContainer("HRTags").GetTag("GridTag", "Debug");
	}
	public static class DungeonTag
	{
		public static Tag Generation => TagContainerCollection.GetContainer("HRTags").GetTag("DungeonTag", "Generation");
		public static Tag PostProcess => TagContainerCollection.GetContainer("HRTags").GetTag("DungeonTag", "PostProcess");
		public static Tag Layout => TagContainerCollection.GetContainer("HRTags").GetTag("DungeonTag", "Layout");
		public static Tag Room => TagContainerCollection.GetContainer("HRTags").GetTag("DungeonTag", "Room");
	}
	public static class EffectsTag
	{
		public static Tag Formula => TagContainerCollection.GetContainer("HRTags").GetTag("EffectsTag", "Formula");
		public static Tag Intent => TagContainerCollection.GetContainer("HRTags").GetTag("EffectsTag", "Intent");
		public static Tag Apply => TagContainerCollection.GetContainer("HRTags").GetTag("EffectsTag", "Apply");
		public static Tag Resolve => TagContainerCollection.GetContainer("HRTags").GetTag("EffectsTag", "Resolve");
		public static Tag Condition => TagContainerCollection.GetContainer("HRTags").GetTag("EffectsTag", "Condition");
	}
	public static class StatsTag
	{
		public static Tag Dependency => TagContainerCollection.GetContainer("HRTags").GetTag("StatsTag", "Dependency");
		public static Tag Calculation => TagContainerCollection.GetContainer("HRTags").GetTag("StatsTag", "Calculation");
		public static Tag Deep => TagContainerCollection.GetContainer("HRTags").GetTag("StatsTag", "Deep");
	}
	public static class EntityTag
	{
		public static Tag Spawn => TagContainerCollection.GetContainer("HRTags").GetTag("EntityTag", "Spawn");
		public static Tag Instance => TagContainerCollection.GetContainer("HRTags").GetTag("EntityTag", "Instance");
		public static Tag Factory => TagContainerCollection.GetContainer("HRTags").GetTag("EntityTag", "Factory");
	}
	public static class ItemTag
	{
		public static Tag Consumable => TagContainerCollection.GetContainer("HRTags").GetTag("ItemTag", "Consumable");
		public static Tag Equippable => TagContainerCollection.GetContainer("HRTags").GetTag("ItemTag", "Equippable");
		public static Tag Instance => TagContainerCollection.GetContainer("HRTags").GetTag("ItemTag", "Instance");
	}
	public static class SkillTag
	{
		public static Tag Use => TagContainerCollection.GetContainer("HRTags").GetTag("SkillTag", "Use");
		public static Tag Paint => TagContainerCollection.GetContainer("HRTags").GetTag("SkillTag", "Paint");
		public static Tag Instance => TagContainerCollection.GetContainer("HRTags").GetTag("SkillTag", "Instance");
	}
	public static class SettingTag
	{
		public static Tag Screen => TagContainerCollection.GetContainer("HRTags").GetTag("SettingTag", "Screen");
		public static Tag Render => TagContainerCollection.GetContainer("HRTags").GetTag("SettingTag", "Render");
		public static Tag Language => TagContainerCollection.GetContainer("HRTags").GetTag("SettingTag", "Language");
		public static Tag Audio => TagContainerCollection.GetContainer("HRTags").GetTag("SettingTag", "Audio");
	}
	public static class FlowControlTag
	{
		public static Tag Constructor => TagContainerCollection.GetContainer("HRTags").GetTag("FlowControlTag", "Constructor");
		public static Tag Setup => TagContainerCollection.GetContainer("HRTags").GetTag("FlowControlTag", "Setup");
		public static Tag EntryPoint => TagContainerCollection.GetContainer("HRTags").GetTag("FlowControlTag", "EntryPoint");
		public static Tag Initialization => TagContainerCollection.GetContainer("HRTags").GetTag("FlowControlTag", "Initialization");
		public static Tag Dispose => TagContainerCollection.GetContainer("HRTags").GetTag("FlowControlTag", "Dispose");
	}
	public static class SaveTag
	{
		public static Tag Load => TagContainerCollection.GetContainer("HRTags").GetTag("SaveTag", "Load");
		public static Tag Save => TagContainerCollection.GetContainer("HRTags").GetTag("SaveTag", "Save");
		public static Tag Slot => TagContainerCollection.GetContainer("HRTags").GetTag("SaveTag", "Slot");
		public static Tag AutoSave => TagContainerCollection.GetContainer("HRTags").GetTag("SaveTag", "AutoSave");
	}
	public static class UITag
	{
		public static Tag Menu => TagContainerCollection.GetContainer("HRTags").GetTag("UITag", "Menu");
		public static Tag Popup => TagContainerCollection.GetContainer("HRTags").GetTag("UITag", "Popup");
		public static Tag Widget => TagContainerCollection.GetContainer("HRTags").GetTag("UITag", "Widget");
		public static Tag Navigation => TagContainerCollection.GetContainer("HRTags").GetTag("UITag", "Navigation");
	}
	public static class DITag
	{
		public static Tag Scope => TagContainerCollection.GetContainer("HRTags").GetTag("DITag", "Scope");
		public static Tag Register => TagContainerCollection.GetContainer("HRTags").GetTag("DITag", "Register");
		public static Tag Resolve => TagContainerCollection.GetContainer("HRTags").GetTag("DITag", "Resolve");
	}
	public static class EventTag
	{
		public static Tag Publish => TagContainerCollection.GetContainer("HRTags").GetTag("EventTag", "Publish");
		public static Tag Subscribe => TagContainerCollection.GetContainer("HRTags").GetTag("EventTag", "Subscribe");
	}
	public static class EditorTag
	{
		public static Tag Validation => TagContainerCollection.GetContainer("HRTags").GetTag("EditorTag", "Validation");
		public static Tag DataBase => TagContainerCollection.GetContainer("HRTags").GetTag("EditorTag", "DataBase");
		public static Tag Table => TagContainerCollection.GetContainer("HRTags").GetTag("EditorTag", "Table");
	}
	public static class ReactiveTag
	{
		public static Tag Subscribe => TagContainerCollection.GetContainer("HRTags").GetTag("ReactiveTag", "Subscribe");
		public static Tag Notify => TagContainerCollection.GetContainer("HRTags").GetTag("ReactiveTag", "Notify");
	}
}

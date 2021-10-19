namespace Zero.Abp.AntBlazor.Layout.Core.LayoutConfig
{
    public class AbpLayoutConfigOptions
    {
        public LayoutSettings Settings { get; set; }

        public AbpLayoutConfigOptions()
        {
            Settings = new LayoutSettings();
        }
    }
}
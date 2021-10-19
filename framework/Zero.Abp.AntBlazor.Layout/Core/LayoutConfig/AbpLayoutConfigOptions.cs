namespace Zero.Abp.AntBlazor.Layout
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
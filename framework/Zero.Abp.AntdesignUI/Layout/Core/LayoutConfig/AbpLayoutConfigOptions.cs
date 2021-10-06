namespace Zero.Abp.AntdesignUI.Layout
{
    public class AbpLayoutConfigOptions
    {
        public LayoutSettings Settings { get; internal set; }


        public AbpLayoutConfigOptions()
        {
            Settings = new LayoutSettings();
        }
    }
}
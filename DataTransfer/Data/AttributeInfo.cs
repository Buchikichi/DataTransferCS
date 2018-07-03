namespace DataTransfer.Data
{
    public class AttributeInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public bool NotNull { get; set; }
        public string DefaultValue { get; set; }
        public bool Pk { get; set; }
        public string Description { get; set; }
    }
}

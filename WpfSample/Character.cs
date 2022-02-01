namespace WpfSample
{
    public class Character : Observable
    {
        private string name = "New Character";
        public string Name
        {
            get => this.name;
            set => SetField(ref this.name, value);
        }

        public AttributeBlock Attributes { get; } = new AttributeBlock();
    }
}
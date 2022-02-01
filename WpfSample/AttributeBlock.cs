namespace WpfSample
{
    public class AttributeBlock : Observable
    {
        private int arcana = 100;
        public int Arcana
        {
            get => this.arcana;
            set => SetField(ref this.arcana, value);
        }
        private int foresight = 100;
        public int Foresight
        {
            get => this.foresight;
            set => SetField(ref this.foresight, value);
        }
        private int might = 100;
        public int Might
        {
            get => this.might;
            set => SetField(ref this.might, value);
        }
        private int resolve = 100;
        public int Resolve
        {
            get => this.resolve;
            set => SetField(ref this.resolve, value);
        }
        private int speed = 100;
        public int Speed
        {
            get => this.speed;
            set => SetField(ref this.speed, value);
        }
    }
}
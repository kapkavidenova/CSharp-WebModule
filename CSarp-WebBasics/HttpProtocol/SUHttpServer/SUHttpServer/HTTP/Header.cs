using SUHttpServer.Common;

namespace SUHttpServer.HTTP
{
    public class Header
    {
        public Header(string _name, string _value)
        {
            Guard.AgainstNull(_name,nameof(_name));
            Guard.AgainstNull(_value,nameof(_value));

            this.Name = _name;
            this.Value = _value;
        }
        public string Name { get; set; }

        public string Value { get; set; }


    }
}

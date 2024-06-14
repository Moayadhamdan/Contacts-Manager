namespace ContactManager
{
    public class Contact
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public Contact(string name, string category)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Contact name cannot be empty or whitespace.");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Contact category cannot be empty or whitespace.");

            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} ({Category})";
        }
    }
}

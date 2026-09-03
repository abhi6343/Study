namespace URLShortener.Builder
{
    internal class ShortenedURL(ShortenedURL.Builder builder)
    {
        public string LongURL => builder.longURL;
        public string ShortKey => builder.shortKey;
        public DateTime CreationDate => builder.creationDate;

        internal class Builder(string longURL, string shortKey)
        {
            internal readonly string longURL = longURL;
            internal readonly string shortKey = shortKey;
            internal DateTime creationDate = DateTime.Now;

            public Builder CreationDate(DateTime creationDate)
            {
                this.creationDate = creationDate;
                return this;
            }

            public ShortenedURL Build()
            {
                return new(this);
            }
        }
    }
}

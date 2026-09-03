namespace LibraryManagementSystem.Entities
{
    internal abstract class LibraryItem(string id, string title)
    {
        protected readonly List<BookCopy> copies = [];
        readonly List<Member> observers = [];

        public void AddCopy(BookCopy copy) { copies.Add(copy); }
        public void AddObserver(Member member) { observers.Add(member); }
        public void RemoveObserver(Member member) { observers.Remove(member); }

        public void NotifyObservers()
        {
            Console.WriteLine($"Notifying {observers.Count} observers for '{title}'...");
            var observersCopy = new List<Member>(observers);
            foreach (var observer in observersCopy)
            {
                observer.Update(this);
            }
        }

        public BookCopy GetAvailableCopy()
        {
            return copies.FirstOrDefault(copy => copy.IsAvailable());
        }

        public string Id => id;
        public string Title => title;
        public List<BookCopy> Copies => copies;

        public abstract string GetAuthorOrPublisher();

        public long GetAvailableCopyCount()
        {
            return copies.Count(copy => copy.IsAvailable());
        }

        public bool HasObservers() { return observers.Count > 0; }
        public bool IsObserver(Member member) { return observers.Contains(member); }
    }
}

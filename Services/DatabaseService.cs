namespace LAB5.Services
{
    public class DatabaseService
    {
        public void Show<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void Add<T>(List<T> list, T item)
        {
            list.Add(item);
            Console.WriteLine("Запись добавлена.");
        }

        public bool Delete<T>(
            List<T> list,
            Predicate<T> condition)
        {
            T item = list.Find(condition);

            if (item == null)
            {
                return false;
            }

            list.Remove(item);
            return true;
        }
    }
}
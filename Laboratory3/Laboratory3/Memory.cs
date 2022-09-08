namespace MemoryObject
{
    public class Memory
    {
        public int MemoryItem { get; set; }

        public void IncreaseMemoryItem(int adder)
        {
            MemoryItem += adder;
        }
        public void DecreaseMemoryItem(int deductor)
        {
            MemoryItem -= deductor;
        }


        public Memory()
        {
            MemoryItem = 0;
        }

        public Memory(int x)
        {
            MemoryItem = x;
        }
    }
}
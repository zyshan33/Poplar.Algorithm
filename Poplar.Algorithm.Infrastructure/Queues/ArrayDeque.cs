namespace Poplar.Algorithm.Infrastructure.Queues
{
    /// <summary>
    /// 数组双端队列
    /// </summary>
    public class ArrayDeque
    {
        private readonly int[] _container;
        private readonly int _maxSize;
        private int _front;
        private int _rear;
        private int _length;

        public ArrayDeque(int k)
        {
            _container = new int[k];
            _maxSize = k;
            _front = 0;
            _rear = 0;
            _length = 0;
        }

        /// <summary>
        /// 为了避免头指针和尾指针指向同一个位置时产生插入和读取的冲突，约定队头入队时时不写当前指针
        ///
        /// 队头写入时，让队头指针自减，当队头为零时再减就是负一，负一是一个无效的数组索引，而此时意味着要从数组的尾部写，
        /// 所以负一的时候就让头指针指向数组的尾部
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InsertFront(int value)
        {
            if (_length == _maxSize)
                return false;
            _front = --_front > -1 ? _front : _maxSize - 1;
            _container[_front] = value;
            _length++;
            return true;
        }

        /// <summary>
        /// 为了避免头指针和尾指针指向同一个位置时产生插入和读取的冲突，约定队尾入队时可写当前指针
        ///
        /// 队尾写入完成之后，让队尾自增一，指向下一个可写入的地址。
        /// 当队尾为数组最后一个索引时，再自增就越界了，而此时意味着下一次写入要从0开始，
        /// 所以自增后是maxSize时，就重置为零。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InsertLast(int value)
        {
            if (_length == _maxSize)
                return false;
            _container[_rear] = value;
            _rear = ++_rear < _maxSize ? _rear : 0;
            _length++;
            return true;
        }

        /// <summary>
        /// 从头部删除，是往数组的右边走，也就是索引自增，
        /// 如果头部是数组的最后一个索引时，再自增就越界了，此时再减就需要回到0.
        /// </summary>
        /// <returns></returns>
        public bool DeleteFront()
        {
            if (_length == 0)
                return false;
            _front = ++_front < _maxSize ? _front : 0;
            _length--;
            return true;
        }

        /// <summary>
        /// 从尾部删除时，是往数组左边走，也就是索引自减。
        /// 如果尾部指向0，再自减就越界，所以此时再自减就要回到数组的最后一个索引
        /// </summary>
        /// <returns></returns>
        public bool DeleteLast()
        {
            if (_length == 0)
                return false;
            _rear = --_rear > -1 ? _rear : _maxSize - 1;
            _length--;
            return true;
        }

        /// <summary>
        /// 约定写的时候当前头指针是有值不可写的，所以读的时候直接读就行。
        /// </summary>
        /// <returns></returns>
        public int GetFront()
        {
            if (_length == 0)
                return -1;
            return _container[_front];
        }

        /// <summary>
        /// 约定写的时候当前尾指针是科协的，所以读的时候要自减，
        /// 此时自减同样需要判断是否到达边界值
        /// </summary>
        /// <returns></returns>
        public int GetRear()
        {
            if (_length == 0)
                return -1;
            var index = _rear - 1;
            index = index > -1 ? index : _maxSize - 1;
            return _container[index];
        }

        public bool IsEmpty()
        {
            return _length == 0;
        }

        public bool IsFull()
        {
            return _length == _maxSize;
        }
    }
}
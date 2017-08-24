using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOffice.Utils
{
    public class ProcessBlock<TParam, TRes>
    {

        public ProcessBlock(Func<TParam, ProcessResult<TRes>> process, ProcessBlock<TParam, TRes> nextBlock = null)
        {
            _process = process;
            _nextBlock = nextBlock;
        }

        public ProcessResult<TRes> Process(TParam data)
        {
            var res = _process(data);
            return res.Processed ? res : _nextBlock != null ? _nextBlock.Process(data) : new ProcessResult<TRes>();
        }

        public static implicit operator ProcessBlock<TParam, TRes>(Func<TParam, ProcessResult<TRes>> func)
        {
            return new ProcessBlock<TParam, TRes>(func);
        }

        private readonly Func<TParam, ProcessResult<TRes>> _process;
        private readonly ProcessBlock<TParam, TRes> _nextBlock;
    }

    public class ProcessResult<T>
    {
        public ProcessResult(T result, bool processed)
        {
            Processed = processed;
            Result = result;
        }

        public ProcessResult()
        {
            Processed = false;
        }

        public bool Processed { get; }
        public T Result { get; }

        public static implicit operator ProcessResult<T>(T val)
        {
            return new ProcessResult<T>(val, val != null);
        }
    }
}

using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FileSystemViewer.Logic.Iterators
{
    internal abstract class FileSystemIterator: IIterator<FileSystemEntry>
    {
        protected bool findDone = false;
        private readonly FileSystemEntry head;

        // переменная будет хранить ссылку на следующий элемент, 
        // если он был найден, но текущая позиция не смещалась.
        protected FileSystemEntry nextFinded;
        
        public FileSystemIterator(FileSystemEntry entry)
        {
            head = entry;
        }

        public FileSystemEntry Current { get; protected set; }

        protected abstract IEnumerable<NextItem> CreateSearchFunctions();

        public bool HasNext
        {
            get
            {
                nextFinded = FindNext();
                return nextFinded != null;
            }
        }

        private FileSystemEntry FindNext()
        {
            FileSystemEntry next = null;

            if (Current != null)
            {
                IEnumerable<NextItem> searchFunctions = CreateSearchFunctions();

                foreach (var functions in searchFunctions)
                {
                    next = functions(Current);
                    if (next != null)
                    {
                        break;
                    }
                }
            }
            else
            {
                next = head;
            }
            nextFinded = next;
            findDone = true;

            return next;
        }

        public void Next()
        {
            if (findDone)
            {
                Current = nextFinded;
            }
            else
            {
                Current = FindNext();
            }
            findDone = false;
            nextFinded = null;
        }

        protected delegate FileSystemEntry NextItem(FileSystemEntry entry);
    }
}

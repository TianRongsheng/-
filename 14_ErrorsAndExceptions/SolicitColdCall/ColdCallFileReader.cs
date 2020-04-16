using System;
using System.IO;

namespace SolicitColdCall
{
    public class ColdCallFileReader : IDisposable
    {
        private FileStream _fs;
        private StreamReader _sr;
        private uint _nPeopleToRing;
        private bool _isDisposed = false;
        private bool _isOpen = false;

       //打开文件，并读取第一行数据
       //有可能引发两个异常
        public void Open(string fileName)
        {
            if (_isDisposed)
            {  //1文件已经销毁
                throw new ObjectDisposedException("peopleToRing");
            }

            _fs = new FileStream(fileName, FileMode.Open);
            _sr = new StreamReader(_fs);

            try
            {
                //2.第一行数字转换不了
                string firstLine = _sr.ReadLine();
                _nPeopleToRing = uint.Parse(firstLine);
                _isOpen = true;
            }
            catch (FormatException ex)
            {
                throw new ColdCallFileFormatException(
                    $"First line isn\'t an integer {ex}");
            }
        }

        //处理文件中的每个人--安全处理
        public void ProcessNextPerson()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");
            }

            if (!_isOpen)
            {
                throw new UnexpectedException(
                    "Attempted to access coldcall file that is not open");
            }

            try
            {
                string name = _sr.ReadLine();
                if (name == null)
                {
                    throw new ColdCallFileFormatException("Not enough names");
                }
                if (name[0] == 'B')
                {
                    throw new SalesSpyFoundException(name);
                }
                Console.WriteLine(name);
            }
            catch (SalesSpyFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }
        //文件中的人数--安全读取
        public uint NPeopleToRing
        {
            get
            {
                if (_isDisposed)
                {
                    throw new ObjectDisposedException("peopleToRing");
                }

                if (!_isOpen)
                {
                    throw new UnexpectedException(
                        "Attempted to access cold–call file that is not open");
                }

                return _nPeopleToRing;
            }
        }
        //销毁
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _isOpen = false;

            _fs?.Dispose();
            _fs = null;
        }
    }
}
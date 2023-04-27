using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakcuulatorNew.Interfaces
{
    public interface IFooModel : IDisposable
    {
        string Name { get;  }
        string Description { set; get; }

        bool IsValid();
    }

    class FooModel : IFooModel
    {
        private string _name;
        public string Name => _name;

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        System.IO.StreamReader _fileReader;
        private void ReadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "TXT|*.txt" };
            string path = openFileDialog.FileName;

            
            

           
            _fileReader = new System.IO.StreamReader(path);
        }
        
        public void Dispose()
        {
            _name = null;
            
            _fileReader.Dispose();
        }

        public bool IsValid()
        {
            return false;
        }
    }


    class BarModel : IFooModel
    {
        public string Name => throw new NotImplementedException();

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

    class ViewModel
    {
        private List<IFooModel> _models = new List<IFooModel>();

        public ViewModel()
        {
            InitModels();
        }

        private void InitModels()
        {
            var foo = new FooModel();
            var bar = new BarModel();

            _models.Add(foo);
            _models.Add(bar);
        }
    }

}

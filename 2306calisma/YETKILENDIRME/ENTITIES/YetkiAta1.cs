using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2306calisma.YETKILENDIRME.ENTITIES
{
    public class YetkiAta1 : INotifyPropertyChanged
    {

        public string TABLO_ADI1 { get; set; }
        private bool _SELECT;
        private bool _UPDATE;
        private bool _INSERT;

        public bool SELECT
        {
            get { return _SELECT; }
            set
            {
                _SELECT = value;
                this.OnPropertyChanged();
            }
        }

        public bool UPDATE
        {
            get { return _UPDATE; }
            set
            {
                _UPDATE = value;
                this.OnPropertyChanged();
            }
        }
        public bool INSERT
        {
            get { return _INSERT; }
            set
            {
                _INSERT = value;
                this.OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            {

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}





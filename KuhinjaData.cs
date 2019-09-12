using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    [Serializable]
    public class KuhinjaData : INotifyPropertyChanged
    {
        string id;
        string ime;
        string prezime;
        string jmbg;
        string brk;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public KuhinjaData()
        {
            id = "";
            ime = "";
            prezime = "";
            jmbg = "";
            brk = "";
        }


        public KuhinjaData(string Id, string Ime, string Prezime, string Jmbg, string Brk)
        {
            this.Id = Id;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Jmbg = Jmbg;
            this.Brk = Brk;
        }

        public string Id { get => id; set { id = value; OnNotifyPropertyChanged("Id"); } }
        public string Ime { get => ime; set { ime = value; OnNotifyPropertyChanged("Ime"); } }
        public string Prezime { get => prezime; set { prezime = value; OnNotifyPropertyChanged("Prezime"); } }
        public string Jmbg { get => jmbg; set { jmbg = value; OnNotifyPropertyChanged("Jmbg"); } }
        public string Brk { get => brk; set { brk = value; OnNotifyPropertyChanged("Brk"); } }




    }



}

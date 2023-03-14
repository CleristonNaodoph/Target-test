
using System.Text.Json;
using Newtonsoft.Json;

namespace Classes
{
    class Estado_fat
    {
        private string? estado;
        private double fat;

        public double Faturamento
        {
            get { return fat; }
            set { fat = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public double participacao(double fat, double total)
        {
            total = (100 * fat) / total;
            return Math.Round((Double)total, 2);
        }

        public Estado_fat(string Estado, double fat)
        {
            this.Estado = Estado;
            this.fat = fat;

        }


    }


    class Filial
    {
    
        public int dia { get; set; }
        public double valor { get; set; }
        public Filial()
        {
        }
        public Filial (Filial fl)
        {
            this.dia=fl.dia;
            this.valor=fl.valor;
        }
        public Filial (int dia, double valor)
        {
            this.dia=dia;
            this.valor=valor;
        }
    }

 
    
    
}

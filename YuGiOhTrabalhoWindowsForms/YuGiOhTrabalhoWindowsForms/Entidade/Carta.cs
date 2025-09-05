using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuGiOhTrabalhoWindowsForms.Entidade
{
    internal class Carta : PictureBox
    {
        public string Nome { get; set; }
        public int Id_Carta { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public Image Frente { get; set; }
        public string Classe { get; set; }
        public string Efeito { get; set; }
        public int Limite { get; set; }
        public string Raridade { get; set; }

        public Carta ()
        {
            SizeMode = PictureBoxSizeMode.StretchImage;
            Width = 80;
            Height = 120;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteIA.Model
{
    public static class Carta
    {
        public static String[] CardInGame { get; set; }
        public static String[] CardInGameCopy { get; set; }
        public static String[][] CardAI { get; set; }
        public static String[][] CardAICopy { get; set; }
        public static int NumCard { get; set; }
    }
}

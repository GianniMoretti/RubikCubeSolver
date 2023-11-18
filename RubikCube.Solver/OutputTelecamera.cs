using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube.Core.Library
{
    public class OutputTelecamera
    {
       
        public Colore[,] Faccia1 { get;private set; }
        public Colore[,] Faccia2 { get;private set; }
        public Colore[,] Faccia3 { get;private set; }
        /// <summary>
        /// le faccie vanno inserite in:sinistra,sotto/sopra,destra
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        public OutputTelecamera(Colore[,]f1, Colore[,] f2, Colore[,] f3)
        {
           

            Faccia1 = f1;
            Faccia2 = f2;
            Faccia3 = f3;
            
        }
        
    }
   

}

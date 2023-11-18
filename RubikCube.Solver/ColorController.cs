using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikCube.Core.Library
{
    public class ColorController
    {
        /// <summary>
        /// Out1=telecamera in basso a destra 
        /// Out2=telecamera in basso a sinistra 
        /// Out3=telecamera in alto a destra 
        /// Out4=telecamera in alto a sinistra 
        /// </summary>
       
        public bool Controlla(OutputTelecamera Out1,OutputTelecamera Out2,OutputTelecamera Out3,OutputTelecamera Out4)
        {
           if(ControlloIncrociato(Out1, Out2, Out3, Out4))
            {

            }
            return false;          
        }
        bool Equals(Colore[,] c1,Colore[,]c2)
        {
            for(int i=0;i<c1.GetLength(0); i++)
            {
                for(int j = 0; j < c1.GetLength(1); j++)
                {

                    if (c1[i, j] != c2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool ControlloIncrociato(OutputTelecamera Out1, OutputTelecamera Out2, OutputTelecamera Out3, OutputTelecamera Out4)
        {
            if (Equals(Out1.Faccia2, Out2.Faccia2))
            {
                //contollo faccia sopra 
                if (Equals(Out3.Faccia2, Out4.Faccia2))
                {
                    //controllo faccia sinistra
                    if (Equals(Out2.Faccia1, Out4.Faccia3))
                    {
                        //controllo Faccia destra
                        if (Equals(Out1.Faccia1, Out3.Faccia3))
                        {
                            //controllo faccia frontale
                            if (Equals(Out2.Faccia3, Out3.Faccia1))
                            {
                                //controllo faccia dietro
                                if (Equals(Out4.Faccia1, Out1.Faccia3))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        void ControlloColori()
        {
            
        }
        List<Colore> CostruisciCubo(OutputTelecamera O1,OutputTelecamera O2)
        {
            List<Colore> ris=new List<Colore>();
            for (int i = 0; i < O1.Faccia1.GetLength(0); i++)
            {
              for(int j = 0; j < O1.Faccia1.GetLength(1);j++)
                {
                    ris.Add(O1.Faccia1[i, j]);
                    ris.Add(O1.Faccia2[i, j]);
                    ris.Add(O1.Faccia3[i, j]);

                    ris.Add(O2.Faccia1[i, j]);
                    ris.Add(O2.Faccia2[i, j]);
                    ris.Add(O2.Faccia3[i, j]);
                }
            }
            return ris;
                    
        }
        
        
    }
}

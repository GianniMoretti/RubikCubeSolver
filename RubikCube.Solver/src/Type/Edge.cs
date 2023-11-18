

namespace RubikCube.Solver
{
    public class Edge
    {
        //nomi da cambiare
        public Color primo;
        public Color secondo;

        /// <summary>
        /// Due spigoli si dicono uguali Anche se la posizione dei colori è invertita.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        public static bool operator ==(Edge left, Edge Right)
        {
            if (left.primo == Right.primo && left.secondo == Right.secondo ||
                left.primo == Right.secondo && left.secondo == Right.primo)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Due Spigoli sono diversi solo se non hanno gli stessi colori, indipendentemente dalla posizione.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        public static bool operator !=(Edge left, Edge Right)
        {
            if (left.primo == Right.primo && left.secondo == Right.secondo ||
                left.primo == Right.secondo && left.secondo == Right.primo)
            {
                return false;
            }
            else
                return true;
        }
    }
}

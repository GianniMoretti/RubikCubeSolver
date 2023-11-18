

namespace RubikCube.Solver
{
    public class Angle
    {
        //Nomi da cambiare
        public Color primo;
        public Color secondo;
        public Color terzo;

        /// <summary>
        /// Due Angoli sono considerati uguali anche se la posizione dei colori è invertita.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        public static bool operator == (Angle left, Angle Right)
        {
            if (left.primo == Right.primo && left.secondo == Right.secondo && left.terzo == Right.terzo ||
                left.primo == Right.primo && left.secondo == Right.terzo && left.terzo == Right.secondo ||
                left.primo == Right.secondo && left.secondo == Right.terzo && left.terzo == Right.primo ||
                left.primo == Right.secondo && left.secondo == Right.primo && left.terzo == Right.terzo ||
                left.primo == Right.terzo && left.secondo == Right.secondo && left.terzo == Right.primo ||
                left.primo == Right.terzo && left.secondo == Right.primo && left.terzo == Right.secondo)
            {
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Due Angoli sono considerati diversi solo se non hanno gli stessi colori non importa se invertiti.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="Right"></param>
        /// <returns></returns>
        public static bool operator != (Angle left, Angle Right)
        {
            if (left.primo == Right.primo && left.secondo == Right.secondo && left.terzo == Right.terzo ||
                left.primo == Right.primo && left.secondo == Right.terzo && left.terzo == Right.secondo ||
                left.primo == Right.secondo && left.secondo == Right.terzo && left.terzo == Right.primo ||
                left.primo == Right.secondo && left.secondo == Right.primo && left.terzo == Right.terzo ||
                left.primo == Right.terzo && left.secondo == Right.secondo && left.terzo == Right.primo ||
                left.primo == Right.terzo && left.secondo == Right.primo && left.terzo == Right.secondo)
            {
                return false;
            }
            else
                return true;
        }
    }
}

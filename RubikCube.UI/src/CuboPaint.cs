using System;
using System.Windows.Forms;
using RubikCube.Solver;

namespace RubikCube.UI
{
    public class CubePicPaint
    {
        private Panel pannello;
        double perAltezza;
        double perLarghezza;
        private int contaPicFatte;
        public CubePicPaint(Panel panel1, Cube c)
        {
            pannello = panel1;
            perLarghezza = (double)pannello.Width / 100;
            perAltezza = (double)pannello.Height / 100;
            CreaFaccia(c.Up, 24 * perLarghezza, 0 * perAltezza);
            CreaFaccia(c.Front, 24 * perLarghezza, 33 * perAltezza);
            CreaFaccia(c.Down, 24 * perLarghezza, 66 * perAltezza);
            CreaFaccia(c.Left, 0 * perLarghezza, 33 * perAltezza);
            CreaFaccia(c.Right, 48 * perLarghezza, 33 * perAltezza);
            CreaFaccia(c.Back, 72 * perLarghezza, 33 * perAltezza);
        }
        public void ReWriteAll(int Width, int Height)
        {
            perLarghezza = Width / 100;
            perAltezza = Height / 100;
            ReWriteOne(24 * perLarghezza, 0 * perAltezza);
            ReWriteOne(24 * perLarghezza, 33 * perAltezza);
            ReWriteOne(24 * perLarghezza, 66 * perAltezza);
            ReWriteOne(0 * perLarghezza, 33 * perAltezza);
            ReWriteOne(48 * perLarghezza, 33 * perAltezza);
            ReWriteOne(72 * perLarghezza, 33 * perAltezza);
            contaPicFatte = 0;
        }
        private void ReWriteOne(double xInizio, double yInizio)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    PictureBox tmp = pannello.Controls[contaPicFatte] as PictureBox;
                    tmp.SetBounds(
                        Convert.ToInt32((x * 8 * perLarghezza) + xInizio),
                        Convert.ToInt32((i * 11 * perAltezza) + yInizio),
                        Convert.ToInt32(7 * perLarghezza),
                        Convert.ToInt32(10 * perAltezza)
                        );
                    contaPicFatte++;
                }
            }
        }
        private void CreaFaccia(Color[,] Faccia, double xInizio, double yInizio)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    PictureBox tmp = new PictureBox();
                    tmp.SetBounds(
                        Convert.ToInt32((x * 8 * perLarghezza) + xInizio),
                        Convert.ToInt32((i * 11 * perAltezza) + yInizio),
                        Convert.ToInt32(7 * perLarghezza),
                        Convert.ToInt32(10 * perAltezza)
                        );
                    tmp.BackColor = GetColor(Faccia[i, x]);
                    pannello.Controls.Add(tmp);
                }
            }
        }
        public void RicoloraFaccie(Cube c)
        {
            contaPicFatte = 0;
            RicoloraFaccia(c.Up);
            RicoloraFaccia(c.Front);
            RicoloraFaccia(c.Down);
            RicoloraFaccia(c.Left);
            RicoloraFaccia(c.Right);
            RicoloraFaccia(c.Back);
        }
        private void RicoloraFaccia(Color[,] Faccia)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    PictureBox a = pannello.Controls[contaPicFatte] as PictureBox;
                    a.BackColor = GetColor(Faccia[i, x]);
                    contaPicFatte++;
                }
            }
        }
        private System.Drawing.Color GetColor(Color colore)
        {
            switch (colore)
            {
                case Color.Rosso:
                    return System.Drawing.Color.Red;
                case Color.Arancione:
                    return System.Drawing.Color.OrangeRed;
                case Color.Bianco:
                    return System.Drawing.Color.White;
                case Color.Blu:
                    return System.Drawing.Color.Blue;
                case Color.Giallo:
                    return System.Drawing.Color.Yellow;
                case Color.Verde:
                    return System.Drawing.Color.Green;
                default:
                    return System.Drawing.Color.Violet;
            }
        }
    }
}

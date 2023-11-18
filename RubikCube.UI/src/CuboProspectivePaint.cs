using System;
using System.Drawing;
using System.Windows.Forms;
using RubikCube.Solver;

namespace RubikCube.UI
{
    public class CuboProspectivePaint
    {
        #region Leggimi 
        //In pratica il problema lo dava perchè iniziava a disegnare prima che la foem fosse caricata, quindi ci ho messo un timer

        //Quando minimizzavi esplodeva perchè chiaraente i punti in cui disegnare non erano all'interno di un cazzo

        /*/
         * Quando rimassimizzavi dava lo stesso problema che all inizio ma in più dava il problema dell'inizio
         * (che disegnava prima che lo form apparisse) e allo stesso tempo splodeva mentre cancellava perchè i 
         * punti dove disegnare li ricalcola solo per disegnare
        /*/

        // un modo per non usare il timer che fa schifo perchè se la form si ricarica in sei ore esplode potrebe essere il resize ended o come si chiama
        //di sicuro all inizio è giusto che aspetti un po ma dopo fa schifo
        #endregion

        double senAngolo;
        double cosAngolo;
        public double latoOrizzontale;
        public double latoVerticale;
        Point Start_Point_Global;
        Point a, a1, a2, b, b1;
        private Cube cubo;

        Panel pannello;
        public CuboProspectivePaint(Panel pnl, Cube cubo)
        {
            this.cubo = cubo;
            pannello = pnl;
            pannello.Paint += ReWriteAll;
            cubo.CuboChanged += ReWriteAll;
            CaricaPunti();
            ReWriteAll(null, EventArgs.Empty);
        }

        private void DisegnaTutto()
        {
            // front
            Visualizza(CreaFaccia(a, 0), cubo.Front, 0);
            VisualizzaContorni(CreaFaccia(a, 0));
            //right
            Visualizza(CreaFaccia(b, 1), cubo.Right, 1);
            VisualizzaContorni(CreaFaccia(b, 1));
            //Up
            Visualizza(CreaFaccia(a, 2), cubo.Up, 2);
            VisualizzaContorni(CreaFaccia(a, 2));
            //Back
            Visualizza(CreaFaccia(a1, 0), cubo.Back, 3);
            VisualizzaContorni(CreaFaccia(a1, 0));
            //Down
            Visualizza(CreaFaccia(a2, 2), cubo.Down, 4);
            VisualizzaContorni(CreaFaccia(a2, 2));
            //Left
            Visualizza(CreaFaccia(b1, 1), cubo.Left, 5);
            VisualizzaContorni(CreaFaccia(b1, 1));
        }

        private void VisualizzaContorni(VectorOfPoint[,] vectorOfPoint)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Graphics gb = pannello.CreateGraphics();
                    Pen Mypen = new Pen(System.Drawing.Color.Black);
                    gb.DrawPolygon(Mypen, vectorOfPoint[y, x].Points);
                }
            }
        }

        private void CancellaTutto()
        {
            Cancella(CreaFaccia(a, 0));
            Cancella(CreaFaccia(b, 1));
            Cancella(CreaFaccia(a, 2));
            Cancella(CreaFaccia(a1, 0));
            Cancella(CreaFaccia(a2, 2));
            Cancella(CreaFaccia(b1, 1));
        }
        private void ReWriteAll(object sender, EventArgs e)
        {
            try
            {
                CancellaTutto();
            }
            catch
            {
            }
            CaricaPunti();
            try
            {
                DisegnaTutto();
            }
            catch { }
        }
        private void CaricaPunti()
        {
            senAngolo = (double)pannello.Height / (double)(pannello.Height * 2);
            cosAngolo = (double)pannello.Width / (double)(pannello.Width * 1.1);
            latoOrizzontale = (double)pannello.Width / 4;
            latoVerticale = (double)pannello.Height / 4;
            Start_Point_Global = new Point((int)(pannello.Width / 2 - cosAngolo * latoOrizzontale), (int)(pannello.Height / 2 - 2.44 * senAngolo * latoVerticale));
            a = new Point(
            Start_Point_Global.X + 0,
            Start_Point_Global.Y + (int)(senAngolo * latoVerticale)
            );
            a1 = new Point(
               (int)(a.X + 2.1 * cosAngolo * latoOrizzontale),
               (int)(a.Y - 2.1 * senAngolo * latoVerticale)
               );
            a2 = new Point(
              (int)(a.X),
              (int)(a.Y + latoVerticale + 2.1 * senAngolo * latoVerticale)
              );
            b = new Point(
               Start_Point_Global.X + (int)(cosAngolo * latoOrizzontale),
               Start_Point_Global.Y + (int)(senAngolo * latoVerticale * 2)
               );
            b1 = new Point(
              (int)(b.X - 2.1 * cosAngolo * latoOrizzontale),
              (int)(b.Y + -2.1 * senAngolo * latoVerticale)
              );
        }
        private void Visualizza(VectorOfPoint[,] vectorOfPoint, RubikCube.Solver.Color[,] Faccia, int facciaID)
        {
            switch (facciaID)
            {
                case 0:
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[y, x].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                        }
                    }
                    break;
                case 1:
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[y, x].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                        }
                    }
                    break;
                case 2:
                    int yColora = 0;
                    for (int y = 2; y >= 0; y--)
                    {
                        int xColora = 0;
                        for (int x = 0; x < 3; x++)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[xColora, yColora].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                            xColora++;
                        }
                        yColora++;
                    }
                    break;
                case 3:
                    int yColora2 = 0;
                    for (int y = 0; y < 3; y++)
                    {
                        int xColora2 = 0;
                        for (int x = 2; x >= 0; x--)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[yColora2, xColora2].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                            xColora2++;
                        }
                        yColora2++;
                    }
                    break;
                case 4:
                    int yColora5 = 0;
                    for (int y = 0; y < 3; y++)
                    {
                        int xColora5 = 0;
                        for (int x = 0; x < 3; x++)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[xColora5, yColora5].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                            xColora5++;
                        }
                        yColora5++;
                    }
                    break;
                case 5:
                    int yColora3 = 0;
                    for (int y = 0; y < 3; y++)
                    {
                        int xColora3 = 0;
                        for (int x = 2; x >= 0; x--)
                        {
                            Graphics gb = pannello.CreateGraphics();
                            SolidBrush myBrush = new SolidBrush(GetColor(Faccia[y, x]));
                            gb.FillPolygon(myBrush, vectorOfPoint[yColora3, xColora3].Points);
                            gb.Dispose();
                            myBrush.Dispose();
                            xColora3++;
                        }
                        yColora3++;
                    }
                    break;
            }

        }
        private void Cancella(VectorOfPoint[,] vectorOfPoint)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Graphics gb = pannello.CreateGraphics();
                    Pen pen = new Pen(pannello.BackColor);
                    SolidBrush myBrush = new SolidBrush(pannello.BackColor);
                    gb.FillPolygon(myBrush, vectorOfPoint[y, x].Points);
                    gb.DrawPolygon(pen, vectorOfPoint[y, x].Points);
                    gb.Dispose();
                    myBrush.Dispose();
                    pen.Dispose();
                }
            }
        }
        private System.Drawing.Color GetColor(RubikCube.Solver.Color colore)
        {
            switch (colore)
            {
                case RubikCube.Solver.Color.Rosso:
                    return System.Drawing.Color.DarkRed;
                case RubikCube.Solver.Color.Arancione:
                    return System.Drawing.Color.OrangeRed;
                case RubikCube.Solver.Color.Bianco:
                    return System.Drawing.Color.White;
                case RubikCube.Solver.Color.Blu:
                    return System.Drawing.Color.Blue;
                case RubikCube.Solver.Color.Giallo:
                    return System.Drawing.Color.Yellow;
                case RubikCube.Solver.Color.Verde:
                    return System.Drawing.Color.Green;
                default:
                    return System.Drawing.Color.Violet;
            }
        }
        private VectorOfPoint CreaQuadtatino(Point start_Point, int v)
        {
            switch (v)
            {
                case 0:
                    return new VectorOfPoint(
                        start_Point,
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y + senAngolo * latoVerticale / 3)),
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y + senAngolo * latoVerticale / 3 + latoVerticale / 3)),
                        new Point((int)(start_Point.X), (int)(start_Point.Y + latoVerticale / 3))
                    );
                case 1:
                    return new VectorOfPoint(
                        start_Point,
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y - senAngolo * latoVerticale / 3)),
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y - senAngolo * latoVerticale / 3 + latoVerticale / 3)),
                        new Point((int)(start_Point.X), (int)(start_Point.Y + latoVerticale / 3))
                    );
                case 2:
                    return new VectorOfPoint(
                        start_Point,
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y - senAngolo * latoVerticale / 3)),
                        new Point((int)(start_Point.X + 2 * cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y)),
                        new Point((int)(start_Point.X + cosAngolo * latoOrizzontale / 3), (int)(start_Point.Y + senAngolo * latoVerticale / 3))
                    );
            }
            return null;
        }
        private VectorOfPoint[,] CreaFaccia(Point Start_Point_Local, int v)
        {
            // passa v a seconda di quale faccia stai disegnando
            VectorOfPoint[,] mat = new VectorOfPoint[3, 3];
            switch (v)
            {

                case 0:
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            mat[y, x] = CreaQuadtatino(new Point((int)(Start_Point_Local.X + cosAngolo * latoOrizzontale / 3 * x),
                                                               (int)(Start_Point_Local.Y + senAngolo * latoVerticale / 3 * x + latoVerticale / 3 * y)), v);
                        }
                    }
                    break;
                case 1:
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            mat[y, x] = CreaQuadtatino(new Point((int)(Start_Point_Local.X + cosAngolo * latoOrizzontale / 3 * x),
                                                               (int)(Start_Point_Local.Y - senAngolo * latoVerticale / 3 * x + latoVerticale / 3 * y)), v);
                        }
                    }
                    break;
                case 2:
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            mat[y, x] = CreaQuadtatino(new Point((int)(Start_Point_Local.X + cosAngolo * latoOrizzontale / 3 * x + cosAngolo * latoOrizzontale / 3 * y),
                                                               (int)(Start_Point_Local.Y - senAngolo * latoVerticale / 3 * x + senAngolo * latoVerticale / 3 * y)), v);
                        }
                    }
                    break;
            }
            return mat;
        }
    }
}

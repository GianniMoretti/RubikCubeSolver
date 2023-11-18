using System;

namespace RubikCube.Solver
{
    public class Cube
    {
        #region Variabili.private 
        public event EventHandler CuboChanged;

        private Color[,] up = new Color[3, 3];

        private Color[,] down = new Color[3, 3];

        private Color[,] front = new Color[3, 3];

        private Color[,] back = new Color[3, 3];

        private Color[,] left = new Color[3, 3];

        private Color[,] right = new Color[3, 3];

        #endregion Variabili.private

        #region Propietà

        #region propietà.Facce
        public Color[,] Up { get { return up; } }
        public Color[,] Down { get { return down; } }
        public Color[,] Front { get { return front; } }
        public Color[,] Back { get { return back; } }
        public Color[,] Left { get { return left; } }
        public Color[,] Right { get { return right; } }

        #endregion Propietà.Facce

        #region Propietà.Angoli

        public Angle UpFrontRight
        {
            get
            {
                Angle a = new Angle();
                a.primo = up[2, 2];
                a.secondo = right[0, 0];
                a.terzo = front[0, 2];
                return a;
            }
        }

        public Angle UpFrontLeft
        {
            get
            {
                Angle a = new Angle();
                a.primo = up[2, 0];
                a.secondo = left[0, 2];
                a.terzo = front[0, 0];
                return a;
            }
        }

        public Angle UpBackRight
        {
            get
            {
                Angle a = new Angle();
                a.primo = up[0, 2];
                a.secondo = right[0, 2];
                a.terzo = back[0, 0];
                return a;
            }
        }

        public Angle UpBackLeft
        {
            get
            {
                Angle a = new Angle();
                a.primo = up[0, 0];
                a.secondo = left[0, 0];
                a.terzo = back[0, 2];
                return a;
            }
        }

        public Angle DownFrontRight
        {
            get
            {
                Angle a = new Angle();
                a.primo = front[2, 2];
                a.secondo = down[0, 2];
                a.terzo = right[2, 0];
                return a;
            }
        }

        public Angle DownFrontLeft
        {
            get
            {
                Angle a = new Angle();
                a.primo = front[2, 0];
                a.secondo = left[2, 2];
                a.terzo = down[0, 0];
                return a;
            }
        }

        public Angle DownBackRight
        {
            get
            {
                Angle a = new Angle();
                a.primo = back[2, 0];
                a.secondo = right[2, 2];
                a.terzo = down[2, 2];
                return a;
            }
        }

        public Angle DownBackLeft
        {
            get
            {
                Angle a = new Angle();
                a.primo = back[2, 2];
                a.secondo = left[2, 0];
                a.terzo = down[2, 0];
                return a;
            }
        }
        #endregion

        #region Propietà.Spigoli

        public Edge UpFront
        {
            get
            {
                Edge a = new Edge();
                a.primo = up[2, 1];
                a.secondo = front[0, 1];
                return a;
            }
        }

        public Edge UpRight
        {
            get
            {
                Edge a = new Edge();
                a.primo = up[1, 2];
                a.secondo = right[0, 1];
                return a;
            }
        }

        public Edge UpLeft
        {
            get
            {
                Edge a = new Edge();
                a.primo = up[1, 0];
                a.secondo = left[0, 1];
                return a;
            }
        }

        public Edge UpBack
        {
            get
            {
                Edge a = new Edge();
                a.primo = up[0, 1];
                a.secondo = back[0, 1];
                return a;
            }
        }

        public Edge MiddleFrontRight
        {
            get
            {
                Edge a = new Edge();
                a.primo = front[1, 2];
                a.secondo = right[1, 0];
                return a;
            }
        }

        public Edge MiddleFrontLeft
        {
            get
            {
                Edge a = new Edge();
                a.primo = front[1, 0];
                a.secondo = left[1, 2];
                return a;
            }
        }

        public Edge MiddleBackRight
        {
            get
            {
                Edge a = new Edge();
                a.primo = back[1, 0];
                a.secondo = right[1, 2];
                return a;
            }
        }

        public Edge MiddleBackLeft
        {
            get
            {
                Edge a = new Edge();
                a.primo = back[1, 2];
                a.secondo = left[1, 0];
                return a;
            }
        }

        public Edge DownFront
        {
            get
            {
                Edge a = new Edge();
                a.primo = down[0, 1];
                a.secondo = front[2, 1];
                return a;
            }
        }

        public Edge DownRight
        {
            get
            {
                Edge a = new Edge();
                a.primo = down[1, 2];
                a.secondo = right[2, 1];
                return a;
            }
        }

        public Edge DownLeft
        {
            get
            {
                Edge a = new Edge();
                a.primo = down[1, 0];
                a.secondo = left[2, 1];
                return a;
            }
        }

        public Edge DownBack
        {
            get
            {
                Edge a = new Edge();
                a.primo = down[2, 1];
                a.secondo = back[2, 1];
                return a;
            }
        }

        #endregion Propietà.Spigoli

        #endregion Propietà

        #region Movimenti

        private void CambiaRiga(Color[,] FacciaDaCambiare, Color[,] FacciaDacCopiare, int RigaDaCambiare)
        {
            for (int i = 0; i < 3; i++)
                FacciaDaCambiare[RigaDaCambiare, i] = FacciaDacCopiare[RigaDaCambiare, i];
        }

        private void CambiaColonna(Color[,] FacciaDaCambiare, Color[,] FacciaDacCopiare, int ColonnaDaCambiare)
        {
            for (int i = 0; i < 3; i++)
                FacciaDaCambiare[i, ColonnaDaCambiare] = FacciaDacCopiare[i, ColonnaDaCambiare];
        }

        private void Orario(Color[,] faccia)
        {
            //Cambio la faccia (ANGOLI)
            Color appoggio1 = faccia[0, 0];
            faccia[0, 0] = faccia[2, 0];
            faccia[2, 0] = faccia[2, 2];
            faccia[2, 2] = faccia[0, 2];
            faccia[0, 2] = appoggio1;

            //Cambio la faccia (SPIGOLI)
            Color appoggio2 = faccia[0, 1];
            faccia[0, 1] = faccia[1, 0];
            faccia[1, 0] = faccia[2, 1];
            faccia[2, 1] = faccia[1, 2];
            faccia[1, 2] = appoggio2;
        }

        private void AntiOrario(Color[,] faccia)
        {
            //Cambio la faccia (ANGOLI)
            Color appoggio1 = faccia[0, 0];
            faccia[0, 0] = faccia[0, 2];
            faccia[0, 2] = faccia[2, 2];
            faccia[2, 2] = faccia[2, 0];
            faccia[2, 0] = appoggio1;

            //Cambio la faccia (SPIGOLI)
            Color appoggio2 = faccia[0, 1];
            faccia[0, 1] = faccia[1, 2];
            faccia[1, 2] = faccia[2, 1];
            faccia[2, 1] = faccia[1, 0];
            faccia[1, 0] = appoggio2;
        }

        #region Grandi
        private void U()
        {
            //Gira le faccie: 
            //metto su una variabile Colore la matrice della faccia sinistra
            //quella frontale passa a sinistra
            //quella da destra passa a frontale
            //da dietro passa a destra
            //passo quella di appoggio dietro
            Color[,] appoggio = (Color[,])left.Clone();
            CambiaRiga(left, front, 0);
            CambiaRiga(front, right, 0);
            CambiaRiga(right, back, 0);
            CambiaRiga(back, appoggio, 0);

            Orario(up);
        }

        private void U1()
        {
            //Gira le faccie: 
            //metto su una variabile Colore la matrice della faccia destra
            //quella frontale passa a destra
            //quella da sinistra passa a frontale
            //da dietro passa a sinistra
            //passo quella di appoggio dietro
            Color[,] appoggio = (Color[,])right.Clone();
            CambiaRiga(right, front, 0);
            CambiaRiga(front, left, 0);
            CambiaRiga(left, back, 0);
            CambiaRiga(back, appoggio, 0);

            AntiOrario(up);
        }

        private void D()
        {
            //Gira le faccie: 
            //metto su una variabile Colore la matrice della faccia destra
            //quella frontale passa a destra
            //quella da sinistra passa a frontale
            //da dietro passa a sinistra
            //passo quella di appoggio dietro
            Color[,] appoggio = (Color[,])right.Clone();
            CambiaRiga(right, front, 2);
            CambiaRiga(front, left, 2);
            CambiaRiga(left, back, 2);
            CambiaRiga(back, appoggio, 2);

            Orario(down);
        }

        private void D1()
        {
            //Gira le faccie: 
            //metto su una variabile Colore la matrice della faccia sinistra
            //quella frontale passa a sinistra
            //quella da destra passa a frontale
            //da dietro passa a destra
            //passo quella di appoggio dietro
            Color[,] appoggio = (Color[,])left.Clone();
            CambiaRiga(left, front, 2);
            CambiaRiga(front, right, 2);
            CambiaRiga(right, back, 2);
            CambiaRiga(back, appoggio, 2);

            AntiOrario(down);
        }

        private void F()
        {
            Orario(front);

            Color[,] appoggio = (Color[,])up.Clone();

            //Da sinistra all'alto
            up[2, 0] = left[2, 2];
            up[2, 1] = left[1, 2];
            up[2, 2] = left[0, 2];

            //Da basso a sinistra
            left[0, 2] = down[0, 0];
            left[1, 2] = down[0, 1];
            left[2, 2] = down[0, 2];

            //Da destra a basso
            down[0, 0] = right[2, 0];
            down[0, 1] = right[1, 0];
            down[0, 2] = right[0, 0];

            //Da alto a destra
            right[2, 0] = appoggio[2, 2];
            right[1, 0] = appoggio[2, 1];
            right[0, 0] = appoggio[2, 0];
        }

        private void F1()
        {
            AntiOrario(front);

            Color[,] appoggio = (Color[,])up.Clone();

            //da destra a alto
            up[2, 0] = right[0, 0];
            up[2, 1] = right[1, 0];
            up[2, 2] = right[2, 0];

            //da basso a destra
            right[0, 0] = down[0, 2];
            right[1, 0] = down[0, 1];
            right[2, 0] = down[0, 0];

            //da sinistra a basso
            down[0, 0] = left[0, 2];
            down[0, 1] = left[1, 2];
            down[0, 2] = left[2, 2];

            //da alto a sinistra
            left[0, 2] = appoggio[2, 2];
            left[1, 2] = appoggio[2, 1];
            left[2, 2] = appoggio[2, 0];
        }

        private void B1()
        {
            AntiOrario(back);

            Color[,] appoggio = (Color[,])right.Clone();

            //da alto a destra
            right[0, 2] = up[0, 0];
            right[1, 2] = up[0, 1];
            right[2, 2] = up[0, 2];

            //da sinistra a alto
            up[0, 0] = left[2, 0];
            up[0, 1] = left[1, 0];
            up[0, 2] = left[0, 0];

            //da basso a sinistra
            left[2, 0] = down[2, 2];
            left[1, 0] = down[2, 1];
            left[0, 0] = down[2, 0];

            //da destra a basso
            down[2, 2] = appoggio[0, 2];
            down[2, 1] = appoggio[1, 2];
            down[2, 0] = appoggio[2, 2];
        }

        private void B()
        {
            Orario(back);

            Color[,] appoggio = (Color[,])left.Clone();

            //da alto a sinistra
            left[0, 0] = up[0, 2];
            left[1, 0] = up[0, 1];
            left[2, 0] = up[0, 0];

            //da destra a alto
            up[0, 2] = right[2, 2];
            up[0, 1] = right[1, 2];
            up[0, 0] = right[0, 2];

            //da basso a destra
            right[2, 2] = down[2, 0];
            right[1, 2] = down[2, 1];
            right[0, 2] = down[2, 2];

            //da sinistra a basso
            down[2, 0] = appoggio[0, 0];
            down[2, 1] = appoggio[1, 0];
            down[2, 2] = appoggio[2, 0];
        }

        private void L()
        {
            Orario(left);

            Color[,] appoggio = (Color[,])up.Clone();

            //da dietro a sopra 
            up[0, 0] = back[2, 2];
            up[1, 0] = back[1, 2];
            up[2, 0] = back[0, 2];

            //da sotto a dietro
            back[2, 2] = down[0, 0];
            back[1, 2] = down[1, 0];
            back[0, 2] = down[2, 0];

            //da frontale a sotto
            CambiaColonna(down, front, 0);

            //da sopra a frontale
            CambiaColonna(front, appoggio, 0);
        }

        private void L1()
        {
            AntiOrario(left);

            Color[,] appoggio = (Color[,])up.Clone();

            //da frontale a superiore
            CambiaColonna(up, front, 0);

            //da sotto a frontale
            CambiaColonna(front, down, 0);

            //da dietro a sotto
            down[0, 0] = back[2, 2];
            down[1, 0] = back[1, 2];
            down[2, 0] = back[0, 2];

            //da sopra a dietro 
            back[2, 2] = appoggio[0, 0];
            back[1, 2] = appoggio[1, 0];
            back[0, 2] = appoggio[2, 0];
        }

        private void R()
        {
            Orario(right);

            Color[,] appoggio = (Color[,])up.Clone();

            //da frontale a superiore
            CambiaColonna(up, front, 2);

            //da sotto a frontale
            front[0, 2] = down[0, 2];
            front[1, 2] = down[1, 2];
            front[2, 2] = down[2, 2];
            CambiaColonna(front, down, 2);

            //da dietro a sotto
            down[0, 2] = back[2, 0];
            down[1, 2] = back[1, 0];
            down[2, 2] = back[0, 0];

            //da sopra a dietro
            back[2, 0] = appoggio[0, 2];
            back[1, 0] = appoggio[1, 2];
            back[0, 0] = appoggio[2, 2];
        }

        private void R1()
        {
            AntiOrario(right);

            Color[,] appoggio = (Color[,])up.Clone();

            //da dietro a sopra 
            up[0, 2] = back[2, 0];
            up[1, 2] = back[1, 0];
            up[2, 2] = back[0, 0];

            //da sotto a dietro
            back[2, 0] = down[0, 2];
            back[1, 0] = down[1, 2];
            back[0, 0] = down[2, 2];

            //da davanti a sotto
            CambiaColonna(down, front, 2);

            //da sopra a davanti
            CambiaColonna(front, appoggio, 2);
        }

        private void X()
        {
            Color[,] appoggio = (Color[,])up.Clone();
            up = front;
            front = (Color[,])down.Clone();
            down =SpecchiaFaccieX( back);
            back =SpecchiaFaccieX( appoggio);
            Orario(right);
            AntiOrario(left);
        }

        private void X1()
        {
            Color[,] appoggio = (Color[,])up.Clone();
            up= SpecchiaFaccieX( back);
            back =SpecchiaFaccieX( down);
            down = front;
            front = appoggio;
            Orario(left);
            AntiOrario(right);
        }

        private Color[,] SpecchiaFaccieX(Color[,] daCopiare)
        {
            Color[,] daCambiare = new Color[3, 3];
            daCambiare[0, 0] = daCopiare[2, 2];
            daCambiare[1, 0] = daCopiare[1, 2];
            daCambiare[2, 0] = daCopiare[0, 2];
            daCambiare[0, 1] = daCopiare[2, 1];
            daCambiare[1, 1] = daCopiare[1, 1];
            daCambiare[2, 1] = daCopiare[0, 1];
            daCambiare[0, 2] = daCopiare[2, 0];
            daCambiare[1, 2] = daCopiare[1, 0];
            daCambiare[2, 2] = daCopiare[0, 0];
            return daCambiare;
        }

        private void Y()
        {
            Color[,] appoggio = (Color[,])front.Clone();
            front = right;
            right = back;
            back = left;
            left = appoggio;
            Orario(up);
            AntiOrario(down);
        }

        private void Y1()
        {
            Color[,] appoggio = (Color[,])front.Clone();
            front = left;
            left = back;
            back = right;
            right = appoggio;
            Orario(down);
            AntiOrario(up);
        }

        private void Z()
        {
            X();
            Y();
            X1();
        }

        private void Z1()
        {
            X();
            Y1();
            X1();
        }

        private Color[,] SpecchiaFaccieZ(Color[,] daCopiare)
        {
            Color[,] daCambiare = new Color[3, 3];
            daCambiare[0, 0] = daCopiare[0, 2];
            daCambiare[1, 0] = daCopiare[0, 1];
            daCambiare[2, 0] = daCopiare[0, 0];
            daCambiare[0, 1] = daCopiare[1, 2];
            daCambiare[1, 1] = daCopiare[1, 1];
            daCambiare[2, 1] = daCopiare[1, 0];
            daCambiare[0, 2] = daCopiare[2, 2];
            daCambiare[1, 2] = daCopiare[2, 1];
            daCambiare[2, 2] = daCopiare[2, 0];
            return daCambiare;
        }

        private void M()
        {
            R();
            L1();
            X1();
        }

        private void M1()
        {
            X();
            L();
            R1();
        }

        private void E()
        {
            U();
            D1();
            Y1();
        }

        private void E1()
        {
            Y();
            D();
            U1();
        }

        private void S()
        {
            F1();
            B();
            Z();
        }

        private void S1()
        {
            Z1();
            B1();
            F();
        }
        #endregion

        #region Piccoli
        private void u()
        {
            D();
            Y();
        }

        private void u1()
        {
            Y1();
            D1();
        }

        private void d()
        {
            U();
            Y1();
        }

        private void d1()
        {
            Y();
            U1();
        }

        private void f()
        {
            B();
            Z1();
        }

        private void f1()
        {
            Z();
            B1();
        }

       

        private void b()
        {
            F();
            Z1();
        }
        private void b1()
        {
            Z();
            F1();
        }

        private void l()
        {
            R();
            X1();
        }

        private void l1()
        {
            X();
            R1();
        }

        private void r()
        {
            L();
            X();
        }

        private void r1()
        {
            X1();
            L1();
        }
        #endregion
        public void ExecuteAlgorithm(string Algoritmo)
        {
            string[] s = Algoritmo.Split(',');
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "")
                    continue;
                switch (s[i])
                {
                    case "U":
                        U();
                        break;
                    case "F":
                        F();
                        break;
                    case "B":
                        B();
                        break;
                    case "R":
                        R();
                        break;
                    case "L":
                        L();
                        break;
                    case "D":
                        D();
                        break;
                    case "U1":
                        U1();
                        break;
                    case "F1":
                        F1();
                        break;
                    case "B1":
                        B1();
                        break;
                    case "R1":
                        R1();
                        break;
                    case "L1":
                        L1();
                        break;
                    case "D1":
                        D1();
                        break;
                    case "X":
                        X();
                        break;
                    case "X1":
                        X1();
                        break;
                    case "Y":
                        Y();
                        break;
                    case "Y1":
                        Y1();
                        break;
                    case "Z":
                        Z();
                        break;
                    case "Z1":
                        Z1();
                        break;
                    case "M":
                        M();
                        break;
                    case "M1":
                        M1();
                        break;
                    case "E":
                        E();
                        break;
                    case "E1":
                        E1();
                        break;
                    case "S":
                        S();
                        break;
                    case "S1":
                        S1();
                        break;
                        //piccoli
                    case "u":
                        u();
                        break;
                    case "f":
                        f();
                        break;
                    case "b":
                        b();
                        break;
                    case "r":
                        r();
                        break;
                    case "l":
                        l();
                        break;
                    case "d":
                        d();
                        break;
                    case "u1":
                        u1();
                        break;
                    case "f1":
                        f1();
                        break;
                    case "b1":
                        b1();
                        break;
                    case "r1":
                        r1();
                        break;
                    case "l1":
                        l1();
                        break;
                    case "d1":
                        d1();
                        break;
                }
            }
            CuboChanged?.Invoke(null, EventArgs.Empty);
        }

        #endregion Movimenti

        public Cube()
        {
            GeneraColori();
        }

        private void GeneraColori()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    up[i, x] = Color.Giallo;
                    down[i, x] = Color.Bianco;
                    left[i, x] = Color.Verde;
                    right[i, x] = Color.Blu;
                    back[i, x] = Color.Rosso;
                    front[i, x] = Color.Arancione;
                }
            }
        }

        public string RandomShuffle(string Mosse = null)
        {
            if(Mosse != null)
            {
                string algorithm = "";
                string[] SingoleMosse = Mosse.Split(' ');
                for (int i = 0; i < SingoleMosse.Length; i++)
                {
                    algorithm += "," + SingoleMosse[i];
                }
                ExecuteAlgorithm(algorithm.Substring(1));
                string alg =  algorithm.Substring(1);
                return alg;
            }
            else
            {
                string[] defaultMoves = { "U", "U1", "F", "F1", "L", "L1", "R", "R1", "B", "B1", "D", "D1" };
                string algorithm = "";
                Random rnd = new Random();
                for (int i = 0; i < 20; i++)
                {
                    algorithm += "," + defaultMoves[rnd.Next(1, 12)];
                }
                ExecuteAlgorithm(algorithm.Substring(1));
                return algorithm.Substring(1);
            }
            
        }
    }
}

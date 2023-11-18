using System;
using System.Windows.Forms;

using RubikCube.Solver;


namespace RubikCube.UI
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        Cube cubo = new Cube();
        CuboProspectivePaint cuboProspective;

        private void FrmHome_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            cuboProspective = new CuboProspectivePaint(panel1, cubo);
            WriteLog("                                                    ---------------------------------------------------------------------------------------\r\n                                                                            RAMBUTAN RUBIK CUBE SOLVER\r\n                                                    ---------------------------------------------------------------------------------------\r\n");
        }

        public void WriteLog(string s)
        {
            s = s.Replace(',', ' ');
            s=s.Replace('1','\'');
            txtLog.AppendText(s+"\r\n");
        }

        private void connessioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbMovimenti.Hide();
        }

        private void movimentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grbMovimenti.Show();
        }

        #region btn Movimenti

        private void btnProvaMovimento_Click(object sender, EventArgs e)
        {
            RubikCubeSolver AR = new RubikCubeSolver(cubo);
            var moves = AR.FinalAlgorithm();         
            WriteLog("Solution moves:  " + moves + "\r\n");
        }

        private void btnscombina_Click(object sender, EventArgs e)
        {
            // ATTENTO Hai settato uno specifico scombinamento
            string s = cubo.RandomShuffle("L L' F' L L R U' R' D' R' F' B R F' B D' U' L U' F'");
            cubo.ExecuteAlgorithm(s);//Da provare la prossima volta           
            WriteLog("Random moves:  " + s + "\r\n");
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            cubo.ExecuteAlgorithm(btn.Text);
        }
        #endregion

    }
}

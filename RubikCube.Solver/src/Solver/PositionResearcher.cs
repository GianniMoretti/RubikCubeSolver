

namespace RubikCube.Solver
{
    public class PositionResearcher
    {
        Cube cubo;
        public PositionResearcher(Cube cubo)
        {
            this.cubo = cubo;
        }
        public bool AngleResearcher(Angle tmp,out AnglePosition pos)
        {
             pos = AnglePosition.Unknown;
            if (DownAngleResearcher(tmp, out pos))
                return true;
            if (UpAngleResearcher(tmp, out pos))
                return true;

             return false;
        }
        public bool DownAngleResearcher(Angle tmp,out AnglePosition pos)
        {
            pos = AnglePosition.Unknown;
            if (cubo.DownBackLeft == tmp)
            {
                pos= AnglePosition.DownBackLeft;
                return true;
            }
            if (cubo.DownBackRight == tmp)
            {
                pos = AnglePosition.DownBackRight;
                return true;
            }
            if (cubo.DownFrontLeft == tmp)
            {
                pos = AnglePosition.DownFrontLeft;
                return true;
            }
            if (cubo.DownFrontRight == tmp)
            {
                pos = AnglePosition.DownFrontRight;
                return true;
            }
            return false;
        }
        public bool UpAngleResearcher(Angle tmp,out AnglePosition pos)
        {
            pos = AnglePosition.Unknown;
            if (cubo.UpBackLeft == tmp)
            {
                pos = AnglePosition.UpBackLeft;
                return true;
            }
            if (cubo.UpBackRight == tmp)
            {
                pos = AnglePosition.UpBackRight;
                return true;
            }
            if (cubo.UpFrontLeft == tmp)
            {
                pos = AnglePosition.UpFrontLeft;
                return true;
            }
            if (cubo.UpFrontRight == tmp)
            {
                pos = AnglePosition.UpFrontRight;
                return true;
            }
            return false;
        }

        public bool EdgeResearcher(Edge tmp,out EdgePosition pos)
        {
            pos = EdgePosition.Unknown;
            if (DownEdgeResearcher(tmp, out pos))
                return true;
            if (MiddleAEdgeResearcher(tmp, out pos))
                return true;
            if (UpAEdgeResearcher(tmp, out pos))
                return true;

            return false;
        }
        private bool UpAEdgeResearcher(Edge tmp, out EdgePosition pos)
        {
            pos = EdgePosition.Unknown;
            if (cubo.UpBack == tmp)
            {
                pos = EdgePosition.UpBack;
                return true;
            }
            if (cubo.UpFront == tmp)
            {
                pos = EdgePosition.UpFront;
                return true;
            }
            if (cubo.UpRight == tmp)
            {
                pos = EdgePosition.UpRight;
                return true;
            }
            if (cubo.UpLeft == tmp)
            {
                pos = EdgePosition.UpLeft;
                return true;
            }

            return false;
        }
        private bool MiddleAEdgeResearcher(Edge tmp, out EdgePosition pos)
        {
            pos = EdgePosition.Unknown;
            if (cubo.MiddleBackLeft == tmp)
            {
                pos = EdgePosition.MiddleBackLeft;
                return true;
            }
            if (cubo.MiddleBackRight == tmp)
            {
                pos = EdgePosition.MiddleBackRight;
                return true;
            }
            if (cubo.MiddleFrontLeft == tmp)
            {
                pos = EdgePosition.MiddleFrontLeft;
                return true;
            }
            if (cubo.MiddleFrontRight == tmp)
            {
                pos = EdgePosition.MiddleFrontRight;
                return true;
            }

            return false;
        }
        private bool DownEdgeResearcher(Edge tmp, out EdgePosition pos)
        {
            pos = EdgePosition.Unknown;
            if (cubo.DownBack == tmp)
            {
                pos = EdgePosition.DownBack;
                return true;
            }
            if (cubo.DownFront == tmp)
            {
                pos = EdgePosition.DownFront;
                return true;
            }
            if (cubo.DownLeft == tmp)
            {
                pos = EdgePosition.DownLeft;
                return true;
            }
            if (cubo.DownRight == tmp)
            {
                pos = EdgePosition.DownRight;
                return true;
            }

            return false;
        }
    }
}

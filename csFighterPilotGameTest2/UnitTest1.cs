using System.Windows.Forms;
using System.Drawing;
using csFighterPilotGame;
using Shouldly;

namespace csFighterPilotGameTest2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(12,20,3,5,15,25)]
        [TestCase(1,1,2,2,3,3)]
        public void Given_PictureBox_DeltaX_DeltaY_Move_ShouldResult_PictureBox_Moved_By_X_Y(int x, int y,int deltaX, int deltaY, int newX, int newY)
        {
            PictureBox pb=new PictureBox();
            pb.Left = x;
            pb.Top = y;
            Form1.MovePB(pb, deltaX, deltaY);
            newX.ShouldBe(pb.Left);
            newY.ShouldBe(pb.Top);
        }
    }
}
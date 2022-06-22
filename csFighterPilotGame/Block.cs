using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace csFighterPilotGame
{
    public class Block
    {

        public void MakeBlock(Form1 form)
        {
            Random random = new Random();
            PictureBox block = new PictureBox();
            block.BackColor = Color.Red;
            block.Size = new Size(40, 40);
            block.Tag = "block";
            do
            {
                int x = random.Next(10, Form1.MAX_WIDTH - 10);
                int y = random.Next(50, Form1.MAX_HEIGHT - 50);
                block.Location = new Point(x, y);
            } while (form.IntersectsWith("player", block));
            form.Controls.Add(block);
            block.BringToFront();
        }

    }
}

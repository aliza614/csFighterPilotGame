using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csFighterPilotGame
{
    public class Bullet
    {
        internal string direction;
        internal int X { get; set; }
        internal int Y { get; set; }
        int bulletSpeed = 30;
        PictureBox bullet = new PictureBox();
        Timer timer2 = new Timer();



        //make bullet
        public void MakeBullet(Form1 form)
        {
            bullet = new PictureBox
            {
                BackColor = System.Drawing.Color.Red,
                Size = new System.Drawing.Size(5, 5),
                Location = new System.Drawing.Point(X, Y),
                Tag = "bullet"
            };
            bullet.BringToFront();
            form.Controls.Add(bullet);
            timer2.Interval = bulletSpeed;
            timer2.Tick += new EventHandler(Tm_Tick);
            timer2.Start();
        }
        //tm_tick
        public void Tm_Tick(object sender, EventArgs e)
        {
            if (direction.Equals("left"))
            {
                bullet.Location = new System.Drawing.Point(bullet.Location.X - bulletSpeed, bullet.Location.Y - bulletSpeed);
            }
            if (direction.Equals("right"))
            {
                bullet.Location = new System.Drawing.Point(bullet.Location.X + bulletSpeed, bullet.Location.Y + bulletSpeed);
            }
            if (direction.Equals("up"))
            {
                bullet.Location = new System.Drawing.Point(bullet.Location.X + 0, bullet.Location.Y + bulletSpeed);
            }
            if (bullet.Left < 10 || bullet.Left > 800 - 10 || bullet.Top < 10 || bullet.Top > 600 - 10)
            {
                timer2.Stop();
                timer2.Dispose();
                bullet.Dispose();
                timer2 = null;
                bullet = null;
            }
        }
    }
}

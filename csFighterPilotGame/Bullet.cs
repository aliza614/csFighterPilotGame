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
        int bulletSpeed = Form1.BULLET_SPEED;
        PictureBox bulletPB = new PictureBox();
        Timer timer2 = new Timer();
        //int count = 0;


        //make bullet
        public void MakeBullet(Form1 form, int x, int y)
        {
            bulletPB = new PictureBox
            {
                BackColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(5, 5),

                //Location = new System.Drawing.Point(X, Y),
                Top = y,
                Left = x,
                Tag = "bullet"
            };
            //MessageBox.Show($"X: {X}, Y: {Y} Form1.MAX_HEIGHT: {Form1.MAX_HEIGHT}");
            //MessageBox.Show("making bullet");
            bulletPB.BringToFront();
            form.Controls.Add(bulletPB);
            timer2.Interval = bulletSpeed;
            timer2.Tick += new EventHandler(Tm_Tick);
            timer2.Start();
        }
        //tm_tick
        public void Tm_Tick(object sender, EventArgs e)
        {
            /*do
            {
                MessageBox.Show("the bullet timer is ticking");
            } while (count++ < 5);
            */
            if (direction.Equals("left"))
            {
                Form1.MovePB(bulletPB, -bulletSpeed, -bulletSpeed);
                //X = bullet.Left - bulletSpeed;
                //Y = bullet.Top - bulletSpeed;
                //bullet.Location = new System.Drawing.Point(X, Y);
                //bullet.Top = Y;
                //bullet.Left = X;
            }
            if (direction.Equals("right"))
            {

                //X = bullet.Left + bulletSpeed;
                //Y = bullet.Top - bulletSpeed;
                //bullet.Location = new System.Drawing.Point(X, Y);
                //bullet.Top = Y;
                //bullet.Left = X;
                Form1.MovePB(bulletPB, bulletSpeed, -bulletSpeed);
            }
            if (direction.Equals("up"))
            {
                //X = bullet.Left + 0;
                //Y = bullet.Top - bulletSpeed;
                //bullet.Location = new System.Drawing.Point(X, Y);
                //bullet.Top = Y;
                //bullet.Left = X;
                Form1.MovePB(bulletPB, 0, -bulletSpeed);
            }
            //MessageBox.Show($"the new x is {bullet.Left} the new y is {bullet.Top}");
            if (X < 10 || X > 800 - 10 || Y < 10 || Y > 600 - 10)
            {
                timer2.Stop();
                timer2.Dispose();
                //((Form)sender).Controls.Remove(this.bullet);
                bulletPB.Dispose();
                timer2 = null;
                bulletPB = null;
            }
        }
    }
}

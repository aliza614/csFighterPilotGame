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
        PictureBox bullet = new PictureBox();
        Timer timer2 = new Timer();
        //int count = 0;


        //make bullet
        public void MakeBullet(Form1 form)
        {
            bullet = new PictureBox
            {
                BackColor = System.Drawing.Color.White,
                Size = new System.Drawing.Size(5, 5),
                
                Location = new System.Drawing.Point(X, Y),
                Tag = "bullet"
            };
            MessageBox.Show($"X: {X}, Y: {Y} Form1.MAX_HEIGHT: {Form1.MAX_HEIGHT}");
            //MessageBox.Show("making bullet");
            bullet.BringToFront();
            form.Controls.Add(bullet);
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
                X = bullet.Location.X - bulletSpeed;
                Y = bullet.Location.Y - bulletSpeed;
                bullet.Location = new System.Drawing.Point(X, Y);
            }
            if (direction.Equals("right"))
            {

                X = bullet.Location.X + bulletSpeed;
                Y = bullet.Location.Y - bulletSpeed;
                bullet.Location = new System.Drawing.Point(X,Y);
            }
            if (direction.Equals("up"))
            {

                X = bullet.Location.X + 0;
                Y = bullet.Location.Y - bulletSpeed;
                bullet.Location = new System.Drawing.Point(X,Y);
            }
            MessageBox.Show($"the new x is {X} the new y is {Y}");
            if ( bullet.Left < 10 || bullet.Left > 800 - 10 || bullet.Top < 10 || bullet.Top > 600 - 10)
            {
                timer2.Stop();
                timer2.Dispose();
                ((Form)sender).Controls.Remove(this.bullet);
                bullet.Dispose();
                timer2 = null;
                bullet = null;
                return;
            }
        }
    }
}

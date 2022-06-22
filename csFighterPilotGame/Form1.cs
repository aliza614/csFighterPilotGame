using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csFighterPilotGame
{
    public partial class Form1 : Form
    {
        bool isRight, isLeft;
        string facing = "up";
        int health = 100;
        int points = 0;
        int speed = 20;
        int ammo = 20;
        int bulletSpeed = 30;
        int blockSpeed = 10;
        int score = 0;
        bool isGameOver = false;
        //if you change this must update bullet
        public const int MAX_HEIGHT = 500, MAX_WIDTH = 800;
        public Form1()
        {
            InitializeComponent();
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            //if game is over do nothing
            if (isGameOver) return;
            //if key==h
            if (e.KeyCode == Keys.H)
            {
                //player is going left
                isLeft = true;
                //MessageBox.Show("going left");
            }

            //if key==;
            if (e.KeyCode == Keys.OemSemicolon)
            {    //player is going right
                isRight = true;
                //MessageBox.Show("going right");
            }
            //if key=j
            if (e.KeyCode == Keys.J)
            {    //player.angle="left"
                facing = "left";
                //player.image=playerleft
                player.Image = Properties.Resources.bomber_sprite_left;
            }
            //if key=k
            if (e.KeyCode == Keys.K)
            {
                //player.angle="up"
                facing = "up";
                //player.image=playerUp
                player.Image = Properties.Resources.bomber_sprite;
            }
            //if key=l
            if (e.KeyCode == Keys.L)
            {    //player.angle="right"
                facing = "right";
                //player.image=playerRight
                player.Image = Properties.Resources.bomber_sprite_right;
            }

            //if key=m
            //timer pause
            //if key ==n
            //timer.start
        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (isGameOver) return;
            //if key==h
            if (e.KeyCode == Keys.H)
            {
                //player is going left
                isLeft = false;
               
            }

            //if key==;
            if (e.KeyCode == Keys.OemSemicolon)
            {    //player is going right
                isRight = false;
            }
            //if key==spacebar and you have ammo
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                this.label1.Text = $"    Ammo : {ammo}";
                //player.shoot(facing)
                Shoot(facing);
                if (ammo < 5)
                {
                    DropAmmo();
                }
            }

        }
        public void GameEngine(object o, EventArgs e)
        {
            //check if still have life
            if (health > 1)
            {     //update progressbar
                healthBar.Value = Convert.ToInt32((int)health);
            }
            //else
            else
            {
                //image=image player dead
                player.Image = Properties.Resources.bomber_sprite_dead;
                //timer.Stop()
                timer.Stop();
                //isGameOver=true
                isGameOver = true;

            }
            label1.Text = $"    Ammo : {ammo}";
            label2.Text = $"Points:   {points}";
            if (health < 20)
            {
                healthBar.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                healthBar.ForeColor = System.Drawing.Color.Green;
            }
            if (isLeft && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (isRight && player.Left < MAX_WIDTH - 10)
            {
                player.Left += speed;
            }
            //for each object a in program
            foreach (Control control in player.Controls)
            {


                //if it's a block or a hitblock and a picturebox and it intersects with the bounds of player
                if (control is PictureBox && control.Tag.Equals("ammoRefill"))
                {
                    var ammoRefill = (PictureBox)control;
                    if (ammoRefill.Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(ammoRefill);
                        ammoRefill.Dispose();
                        ammo += 5;
                    }
                }
                if (control is PictureBox && control.Tag.Equals("bullet"))
                {
                    var bullet = (PictureBox)control;
                    //if bullet is off the screen remove & dispose
                    if (bullet.Left < 1 || bullet.Right > MAX_WIDTH || bullet.Top < 1 || bullet.Bottom > MAX_HEIGHT)
                    {
                        this.Controls.Remove(bullet);
                        bullet.Dispose();
                    }
                }
                if (control is PictureBox && control.Tag.Equals("block"))
                {
                    var block = (PictureBox)control;
                    block.Top += blockSpeed;
                    if (block.Bounds.IntersectsWith(player.Bounds))
                    {
                        health -= 1;
                    }
                }
                //if it's a picturebox and a coin and it intersects with the bounds of player
                if (control is PictureBox && control.Tag.Equals("coin"))
                {
                    var coin = (PictureBox)control;
                    //R&D
                    this.Controls.Remove(coin);
                    coin.Dispose();
                    //points++;
                    points++;
                }

                //for each object b in program
                foreach (Control nonPlayer in Controls)
                {
                    //if a is a PictureBox and a bullet
                    if (nonPlayer is PictureBox && nonPlayer.Tag.Equals("bullet"))
                    {
                        var bullet = (PictureBox)nonPlayer;
                        //if b is a PictureBox and a block
                        if (control is PictureBox && control.Tag.Equals("block"))
                        {
                            var block = (PictureBox)control;
                            //change image color or remove
                            switch (block.BackColor.Name)
                            {
                                case "red":
                                    block.BackColor = Color.Yellow;
                                    break;
                                case "yellow":
                                    block.BackColor = Color.Green;
                                    break;
                                case "green":
                                    this.Controls.Remove(block);
                                    block.Dispose();
                                    new Block().MakeBlock(this);
                                    break;
                            }

                            //remove bullet
                            this.Controls.Remove(bullet);
                            bullet.Dispose();

                        }
                    }
                }

            }
        }
        private void DropAmmo()
        {
            Random random = new Random();
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_refill;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = random.Next(10, (int)MAX_WIDTH - 10);
            ammo.Top = random.Next(50, (int)MAX_HEIGHT - 10);
            ammo.Tag = "ammoRefill";
            //for each control check if it intersects, call it again
            foreach (Control control in Controls)
            {
                if (control.Bounds.IntersectsWith(ammo.Bounds))
                {
                    DropAmmo();
                    return;
                }
                this.Controls.Add(ammo);
                ammo.BringToFront();
                player.BringToFront();
            }
        }
        private void Shoot(string direction)
        {
            Bullet bullet = new Bullet();
            bullet.direction = direction;
            bullet.X = player.Left + player.Width / 2;
            bullet.Y = player.Top + player.Height / 2;
            bullet.MakeBullet(this);
        }
        public bool IntersectsWith(string s, PictureBox p)
        {
            foreach (Control c in Controls)
            {
                if (c is PictureBox && c.Tag.Equals(s))
                {
                    PictureBox pb = (PictureBox)c;
                    if (pb.Bounds.IntersectsWith(p.Bounds))
                        return true;
                }
            }
            return false;

        }
    }
}

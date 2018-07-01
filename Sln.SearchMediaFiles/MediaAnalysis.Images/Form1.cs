using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MediaAnalysis.Images
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string imgURL = @"G:\TheGitCloning\cmscustomizations\OnlineOutPatientManagementSystem\OnlineOutPatientManagementSystem\Images\LoginSlide\e.png";
            string imgURL2 = @"G:\Personal Gallery-2\The Padma-Moinot Ghat\20161224_171739.jpg";

            //imageList1.Images.Add("pic1", Image.FromFile(imgURL));
            //Image image = Image.FromFile(imgURL);
            //pictureBox1.Image = image;
            //pictureBox1.Height = image.Height;
            //pictureBox1.Width = image.Width;
            //pictureBox1.ImageLocation = imgURL2;

            //pictureBox1.ImageLocation = imgURL2;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //pictureBox1.ImageLocation = imgURL2;
            //pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            //LoadImageScroller(panel1);
            //DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            //string[] images = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "*.jpg");
            //foreach (string image in images)
            //{
            //    pictureBox1.Image = new Bitmap(image);
            //    Thread.Sleep(500);
            //}
            //panel1.AutoScroll = true;
            //panel1.BorderStyle = BorderStyle.FixedSingle;
            //panel1.SetAutoScrollMargin(100, 100);

            //Form1 oForm1 = new Form1();

            //oForm1.TopLevel = false;
            //oForm1.AutoScroll = true;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(oForm1);
            //panel1.AutoScrollMinSize = new Size(0, oForm1.Height);
            //oForm1.Show();


            //var panel = new FlowLayoutPanel();
            //panel.SuspendLayout(); // don't calculate the layout before all picture boxes are added
            //panel.Size = new Size(491, 152);
            //panel.Location = new Point(12, 12);
            //panel.BorderStyle = BorderStyle.Fixed3D;
            //panel.FlowDirection = FlowDirection.LeftToRight;
            //panel.AutoScroll = true; // automatically add scrollbars if needed
            //panel.WrapContents = false; // all picture boxes in a single row
            //Controls.Add(panel);

            //DynamicPictureBox();

            //panel.ResumeLayout();

        }




        /// <summary>
        /// method for grabbing all the images from your MyPictures directory and load up
        /// a custom Image Scroller for use in a WinForms application
        /// </summary>
        /// <param name="p"></param>
        private void LoadImageScroller(Panel p)
        {
            //load the initial display message
            label1.Text = "Getting wallpapers.....";

            //2 variables, one for the Y position of the current PictureBox control
            //and one for help count the number of images in the directory
            int position = 0;
            int count = 0;

            //string array to hold the valid image formats we want
            string[] validExtensions = new string[] { ".jpg", ".bmp", ".gif", ".png" };

            //now a DirectoryInfo object holding the information from our
            //My Pictures directory
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

            //get all files from the directory and loop through them
            foreach (FileInfo f in info.GetFiles())
            {
                //loop through all the valid types in our array
                for (int i = 0; i < validExtensions.Length; i++)
                {
                    //check and make sure the current file has a valid extension
                    if (f.Extension.ToString().ToLower() == validExtensions[i].ToLower())
                    {
                        //now that we're in our loop create a new PictureBox (this will
                        //create a new one on each iteration of ther loop)
                        PictureBox pb = new PictureBox();

                        //give the PictureBox a name
                        pb.Name = "ImagePB" + count;

                        //set it's cursor type to Hand
                        pb.Cursor = Cursors.Hand;

                        //set the Parent of our control to our Panel, this will cause
                        //the PictureBox to be aded to our Panel
                        pb.Parent = p;
                        pb.Size = new Size(130, 98);

                        //set the SizeMode to StretchImage (this will create thumbnails of our images)
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;

                        //now we se the position of the PictureBox (this is where the position variable comes into
                        //play. We set it to it's value plus 10 (brings it off the left edge of the Panel) and
                        //20 pixels down (so it's not riding the top of the Panel)
                        pb.Location = new Point(position + 10, 20);

                        //Here we use the Image.FromFile method to create a new image
                        //from the current filr name and set the PictureBox's Image value to it
                        pb.Image = Image.FromFile(f.FullName);

                        //set the Tag property of the image to the current image name
                        pb.Image.Tag = f.FullName;

                        //here we're going to add 3 events to our PictureBox:
                        // MouseHove (similar to mouseover in web)
                        //MouseLeave (similar to mouseout in web)
                        //Click (what happens when we click the PictureBox)
                        pb.MouseHover += new EventHandler(pb_MouseHover);
                        pb.MouseLeave += new EventHandler(pb_MouseLeave);
                        pb.Click += new EventHandler(pb_Click);

                        //increment the position value, this makes the next PictureBox
                        //to be 5 pixels to the right of the previous
                        position += 135;

                        //increate the count
                        count += 1;
                    }
                }
            }

            //once we are done loading the images display how many and what directory we're in
            label1.Text = string.Format("{0} image(s) available in directory {1}", count, Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        }



        void pb_MouseHover(object sender, EventArgs e)
        {
            //here we are converting the sender (what is clicked) to a PictureBox and
            //setting a border when it is moused over
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }



        void pb_MouseLeave(object sender, EventArgs e)
        {
            //here we are converting the sender (what is clicked) to a PictureBox and
            //removing the border when the mouse leaves it
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        }



        void pb_Click(object sender, EventArgs e)
        {
            //here we find which PictureBox is clicked and display it's name
            MessageBox.Show(string.Format("Selected Image: {0}", ((PictureBox)sender).Image.Tag.ToString()));
        }



        public void DynamicPictureBox()
        {
            try
            {
                int left = 50;
                int top = 70;

                List<PictureBox> pictureBoxList = new List<PictureBox>();
                DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

                int i = 0;
                foreach (var item in info.GetFiles())
                {
                    PictureBox picture = new PictureBox
                    {
                        Name = "pictureBox" + i,
                        Size = new Size(316, 320),
                        Location = new Point(i * 316, 1),
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    picture.ImageLocation = item.FullName;
                    pictureBoxList.Add(picture);



                    panel1.Left = left;
                    panel1.Top = top;
                    panel1.Controls.Add(picture);
                    if (left + panel1.Width + 100 > 1200)
                    {
                        left = 50;
                        top += panel1.Height + 2;
                    }
                    else
                    {
                        left += panel1.Width + 2;
                    }
                    //panel1.Controls.Add(picture);

                    i++;
                }


                //foreach (PictureBox p in pictureBoxList)
                //{
                //    panel1.Controls.Add(p);
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string imgURL2 = @"C:\Users\shahed\Pictures\kaley-cuoco-penny.jpg";
            int left = 50;
            int top = 70;

            Form1 oForm1 = new Form1();
            var a = oForm1.Width;


            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                button.BackColor = Color.Green;
                button.Width = 220;
                button.Height = 220;

                //Image img = Image.FromFile(imgURL2);
                //button.BackgroundImage = img;
                //CustomButton_Resize(button);


                Image imgPhoto = resizeImage(220, 220, imgURL2);
                button.BackgroundImage = imgPhoto;

                button.Left = left;
                button.Top = top;
                Controls.Add(button);


                if (left + button.Width + 100 > oForm1.Width)
                {
                    left = 50;
                    top += button.Height + 2;
                }
                else
                {
                    left += button.Width + 2;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int left = 50;
            int top = 70;

            Form1 oForm1 = new Form1();
            var a = oForm1.Width;

            string[] validExtensions = new string[] { ".jpg", ".bmp", ".gif", ".png" };
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

            //get all files from the directory and loop through them
            foreach (FileInfo f in info.GetFiles())
            {

                if (validExtensions.Contains(Path.GetExtension(f.Extension).ToLower()))
                {
                    Button button = new Button();
                    button.BackColor = Color.Green;
                    button.Width = 220;
                    button.Height = 220;

                    Image imgPhoto = resizeImage(220, 220, f.FullName);
                    button.BackgroundImage = imgPhoto;

                    button.Left = left;
                    button.Top = top;
                    Controls.Add(button);


                    if (left + button.Width + 100 > oForm1.Width)
                    {
                        left = 50;
                        top += button.Height + 2;
                    }
                    else
                    {
                        left += button.Width + 2;
                    }
                }

                
            }
        }

        void CustomButton_Resize(Button btnIMG)
        {
            if (btnIMG.BackgroundImage == null)
                return;
            var pic = new Bitmap(btnIMG.BackgroundImage, new Size(btnIMG.Width, btnIMG.Height));
            btnIMG.BackgroundImage = pic;
        }


        public Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }


    }
}
